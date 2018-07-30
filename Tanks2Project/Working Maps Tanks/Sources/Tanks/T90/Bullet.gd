extends "res://Tanks/BaseTank/Bullet.gd"

var time_since_hit = 0
var sprite
var hit_wall = false

func explode():
	var explosion = get_node("Particles2D")
	explosion.emitting = true
	sprite.hide()
	velocity = velocity * 0
	set_collision_layer(3)
	set_collision_mask(3)
	if hit_wall:
		get_node("Sounds/WallHit").play()
	else:
		get_node("Sounds/TankHit").play()

func _ready():
	._ready()
	self.rotate(velocity.angle() + 1.57)
	sprite = get_node("Sprite")

func bounce(collision):
	hit_wall = true
	explode()

func _physics_process(delta):
	if !sprite.visible:
		time_since_hit += delta
		if time_since_hit >= 3:
			queue_free()