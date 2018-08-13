extends "res://Tanks/BaseTank/Bullet.gd"

export var expiration_seconds = 3
var time = 0

func _process(delta):
	time += delta
	if time >= expiration_seconds:
		self.queue_free()
	pass
