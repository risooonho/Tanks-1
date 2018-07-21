extends KinematicBody2D

signal destroy

export var UP = KEY_UP
export var DOWN = KEY_DOWN
export var LEFT = KEY_LEFT
export var RIGHT = KEY_RIGHT
export var SHOOT = KEY_M
export var rotation_speed = 5
export var movement_speed = 130
export var go_back_speed_multiplier = 0.5
export (int) var HP = 1 setget set_HP
var velocity
var rot = 0
var bullet_scene
var pos


func set_HP(value):
	if value == 0:
		HP = 1
		emit_signal("destroy")
	else:
		HP = value

func take_hit(value):
	self.HP -= value

func _ready():
	connect("destroy", self, "on_destroy")
	var bullet_path = get_script().get_path().get_base_dir()
	bullet_scene = load(bullet_path + "/Bullet.tscn")
	pos = get_node("ShootPosition")
	add_to_group("Tanks")

func shoot():
	var new_bullet = bullet_scene.instance()
	new_bullet.velocity = Vector2(0, -1).rotated(rot) * new_bullet.speed
	new_bullet.global_position = pos.global_position
	get_parent().add_child(new_bullet)

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
	if event is InputEventKey:
		if event.scancode == SHOOT and event.pressed and not event.echo:
			shoot()

func _physics_process(delta):
	control(delta)
	velocity = move_and_slide(velocity)
	
func on_destroy():
	hide()
