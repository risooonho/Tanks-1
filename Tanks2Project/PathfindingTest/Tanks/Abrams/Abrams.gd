extends "res://Tanks/BaseTank/Tank.gd"

var destroyed = false
var time_since_destroy = 0
var can_shoot = true

func shoot():
	if can_shoot:
		.shoot()
		get_node("AnimatedSprite").playing = true
		get_node("AnimatedSprite").frame = 1
		get_node("Sounds/Fire").play()
		can_shoot = false

func _on_Fire_Sound_finished():
	get_node("Sounds/Reload").play()

func _on_Reload_Sound_finished():
	can_shoot = true

func _on_AnimatedSprite_animation_finished():
	get_node("AnimatedSprite").playing = false
	get_node("AnimatedSprite").frame = 0

func _physics_process(delta):
	if destroyed:
		time_since_destroy += delta
		if time_since_destroy >= 2:
			get_node("Explosion").emitting = false
			self.hide()
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
	get_node("AnimatedSprite").hide()
	destroyed = true
	get_node("Explosion").emitting = true
	get_node("Trail").hide()
	get_node("Sounds/Explode").play()

func collide_again():
	.collide_again()
	get_node("AnimatedSprite").show()
	get_node("Trail").show()
	destroyed = false
	time_since_destroy = 0

