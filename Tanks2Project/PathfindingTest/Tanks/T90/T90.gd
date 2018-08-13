extends "res://Tanks/BaseTank/Tank.gd"

var destroyed = false
var time_since_destroy = 0
var can_shoot = true

func shoot():
	if can_shoot:
		.shoot()
		get_node("Sounds/Shoot").play()
		can_shoot = false

func _on_Fire_Sound_finished():
	get_node("Sounds/Reload").play()

func _on_Reload_Sound_finished():
	can_shoot = true

func _physics_process(delta):
	if destroyed:
		time_since_destroy += delta
		if time_since_destroy >= 2:
			get_node("Explosion").emitting = false
			hide()
			time_since_destroy = 0
			destroyed = false
	if velocity != null:
		var ok = self.velocity.length() != 0
		get_node("Trail").emitting = ok
		if ok:
			if !get_node("Sounds/Move").playing:
				get_node("Sounds/Move").play()
		else:
			get_node("Sounds/Move").stop()

func on_destroy():
	set_collision_mask(2)
	set_collision_layer(2)
	get_node("Sprite").hide()
	destroyed = true
	get_node("Explosion").emitting = true
	get_node("Sounds/Explode").play()

func collide_again():
	.collide_again()
	get_node("Sprite").show()
	destroyed = false
	time_since_destroy = 0

