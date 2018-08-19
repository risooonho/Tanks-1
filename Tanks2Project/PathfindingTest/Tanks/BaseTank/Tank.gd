extends KinematicBody2D

signal destroy
signal public_destroy
var player_name = "player" setget set_player

export var UP = KEY_UP
export var DOWN = KEY_DOWN
export var LEFT = KEY_LEFT
export var RIGHT = KEY_RIGHT
export var SHOOT = KEY_M
export var rotation_speed = 5
export var movement_speed = 130
export var go_back_speed_multiplier = 0.5
export var health = 1
var HP setget set_HP
var velocity = Vector2(0, 0)
var rot = 0
var bullet_scene
var pos
export var is_controlled_by_mobile = false
var CONTROLLER_UP = false
var CONTROLLER_DOWN = false
var CONTROLLER_LEFT = false
var CONTROLLER_RIGHT = false
var CONTROLLER_SHOOT = false
var control_func
var killed = false

export var AI = false
export var seconds_between_path_updates = 1
export var stop_at_distance = 30
export var clear_path_points_at = 30
export var minimum_shoot_cooldown = 0.5
export var field_of_detection = 10000
var nav = null
var current_target = null
var path
var time_since_update = 2
var time_since_shoot = minimum_shoot_cooldown
var RayCast
var can_see_tank = false

#var NavPoint = preload("res://NavPoint.tscn")

export var player_name_label = preload("res://Tanks/BaseTank/PlayerNameText.tscn")
export var label_position = Vector2(0, 20)

func set_HP(value):
	if value <= 0:
		HP = health
		killed = true
		emit_signal("destroy")
		emit_signal("public_destroy", player_name)
	else:
		HP = value

func set_player(value):
	var text = get_node("PlayerNameText")
	if text:
		text.player_name = value
	player_name = value

func _ready():
	HP = health
	connect("destroy", self, "on_destroy")
	var bullet_path = get_script().get_path().get_base_dir()
	bullet_scene = load(bullet_path + "/Bullet.tscn")
	RayCast = $RayCast2D
	pos = $ShootPosition
	add_to_group("Tanks")
	var label = player_name_label.instance()
	label.position_relative_to_player = label_position
	add_child(label)
	
	if AI:
		RayCast.enabled = true
		control_func = "AI_control"
		pass
	elif is_controlled_by_mobile:
		control_func = "mobile_control"
	else:
		control_func = "control"

func shoot():
	var new_bullet = bullet_scene.instance()
	new_bullet.velocity = Vector2(0, -1).rotated(rot) * new_bullet.speed
	new_bullet.global_position = pos.global_position
	get_parent().add_child(new_bullet)

func AI_find_target():
	var min_dist = field_of_detection
	var target = null
	for tank in get_tree().get_nodes_in_group("Tanks"):
		if tank != self && tank.visible:
			var dist = tank.global_position.distance_to(global_position)
			if dist < min_dist:
				min_dist = dist
				target = tank
	return target

func AI_perform_rotation(straight, vect_to_target, delta):
	var rt = 0
	var angle = atan2(straight.x * vect_to_target.y - straight.y * vect_to_target.x, straight.x * vect_to_target.x + straight.y * vect_to_target.y)
	if angle < 0:
		rt = -1
	else:
		rt = 1 
	rt = rt * rotation_speed * delta
	rotate(rt)
	rot += rt

func AI_perform_shoot(delta):
	if time_since_shoot > minimum_shoot_cooldown:
		if RayCast:
			if RayCast.get_collider():
				can_see_tank = RayCast.get_collider().is_in_group("Tanks")
				if can_see_tank:
					shoot()
					time_since_shoot = 0

func AI_control(delta):
	AI_perform_shoot(delta)
	time_since_update += delta
	time_since_shoot += delta
	current_target = AI_find_target()
	if current_target:
		if time_since_update > seconds_between_path_updates:
			nav = get_tree().get_nodes_in_group("Maps")[0].get_node("Navigation2D")
			path = nav.get_simple_path(global_position, current_target.global_position, false)
			time_since_update = 0
			#for p in get_tree().get_nodes_in_group("Test"):
				#p.free()
			#for p in path:
				#var np = NavPoint.instance()
				#np.global_position = p
				#np.add_to_group("Test")
				#get_parent().add_child(np)
			
		if path.size() > 0:
			var vect_to_target = (path[0] - global_position).normalized()
			var straight = Vector2(0, -1).rotated(rot)
			AI_perform_rotation(straight, vect_to_target, delta)
			if current_target.global_position.distance_to(global_position) > stop_at_distance || !can_see_tank:
				velocity = Vector2(0, -movement_speed).rotated(rot)
			elif can_see_tank:
				velocity = Vector2(0, 0)
				vect_to_target = (current_target.global_position - global_position).normalized()
				straight = Vector2(0, -1).rotated(rot)
				AI_perform_rotation(straight, vect_to_target, delta)
			while path.size() >= 1 && path[0].distance_to(global_position) < clear_path_points_at:
				path.remove(0)
	else:
		velocity = Vector2(0, 0)

func mobile_control(delta):
	var rt = 0
	velocity = Vector2(0, 0)
	
	if CONTROLLER_LEFT:
		rt-=1
	elif CONTROLLER_RIGHT:
		rt+=1
	rt = rt * rotation_speed * delta
	rotate(rt)
	rot += rt
	
	if CONTROLLER_UP:
		velocity = Vector2(0, -movement_speed).rotated(rot)
	elif CONTROLLER_DOWN:
		velocity = Vector2(0, movement_speed * go_back_speed_multiplier).rotated(rot)
	
	if CONTROLLER_SHOOT:
		CONTROLLER_SHOOT = false
		shoot()

func control(delta):
	var rt = 0
	velocity = Vector2(0, 0)
	
	if Input.is_key_pressed(LEFT):
		rt-=1
	elif Input.is_key_pressed(RIGHT):
		rt+=1
	rt = rt * rotation_speed * delta
	rotate(rt)
	rot += rt
	
	if Input.is_key_pressed(UP):
		velocity = Vector2(0, -movement_speed).rotated(rot)
	elif Input.is_key_pressed(DOWN):
		velocity = Vector2(0, movement_speed * go_back_speed_multiplier).rotated(rot)

func _input(event):
	if !is_controlled_by_mobile && !AI && visible && event is InputEventKey:
		if event.scancode == SHOOT and event.pressed and not event.echo:
			shoot()

func _physics_process(delta):
	if !killed:
		call(control_func, delta)
		velocity = move_and_slide(velocity)
	else:
		velocity = Vector2(0, 0)

func take_hit(value):
	self.HP -= value

func collide_again():
	set_collision_layer(1)
	set_collision_mask(1)
	killed = false

func on_destroy():
	set_collision_mask(2)
	set_collision_layer(2)
	hide()
