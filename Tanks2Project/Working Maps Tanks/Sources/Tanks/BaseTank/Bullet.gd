extends KinematicBody2D

export var velocity = Vector2(0, 0)
export var speed = 200
export var damage = 1

func bounce(collision):
	var normal = collision.normal
	velocity = -velocity.reflect(normal)

func _ready():
	add_to_group("Bullets")

func _physics_process(delta):
	var collision = move_and_collide(velocity * delta)
	if collision != null:
		if collision.collider.is_in_group("Tanks"):
			queue_free()
			collision.collider.call("take_hit", damage)
		else:
			bounce(collision)
