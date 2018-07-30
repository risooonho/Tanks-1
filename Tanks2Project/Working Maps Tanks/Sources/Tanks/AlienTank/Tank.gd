extends "res://Tanks/BaseTank/Tank.gd"

var pos_down
var pos_left
var pos_right
var respawned = false

# class member variables go here, for example:
# var a = 2
# var b = "textvar"

func _ready():
	pos_down = get_node("ShootPosition4")
	pos_left = get_node("ShootPosition3")
	pos_right = get_node("ShootPosition2")
	pass

func _physics_process(delta):
	if velocity != null:
		if self.velocity.length() != 0:
			if !get_node("Sounds/Move").playing:
				get_node("Sounds/Move").play()
		else:
			get_node("Sounds/Move").stop()

func shoot():
	get_node("Sounds/Shoot").play()
	
	var new_bullet_up = bullet_scene.instance()
	new_bullet_up.velocity = Vector2(0, -1).rotated(rot) * new_bullet_up.speed
	new_bullet_up.global_position = pos.global_position
	get_parent().add_child(new_bullet_up)
	
	var new_bullet_down = bullet_scene.instance()
	new_bullet_down.velocity = Vector2(0, 1).rotated(rot) * new_bullet_down.speed
	new_bullet_down.global_position = pos_down.global_position
	get_parent().add_child(new_bullet_down)
	
	var new_bullet_left = bullet_scene.instance()
	new_bullet_left.velocity = Vector2(-1, 0).rotated(rot) * new_bullet_left.speed
	new_bullet_left.global_position = pos_left.global_position
	get_parent().add_child(new_bullet_left)
	
	var new_bullet_right = bullet_scene.instance()
	new_bullet_right.velocity = Vector2(1, 0).rotated(rot) * new_bullet_right.speed
	new_bullet_right.global_position = pos_right.global_position
	get_parent().add_child(new_bullet_right)


func on_destroy():
	set_collision_mask(2)
	set_collision_layer(2)
	get_node("AnimationPlayer").play("Destroy")
	
func _on_AnimationPlayer_animation_finished(anim_name):
	if anim_name == "Destroy":
		if !respawned:
			hide()
		get_node("Sprite2").frame = 0

func collide_again():
	.collide_again()
	respawned = true