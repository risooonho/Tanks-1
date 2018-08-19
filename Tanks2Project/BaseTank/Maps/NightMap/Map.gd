extends Sprite

var occluders_func = "create_occluders"
var tanks_count = 0

func create_occluders():
	var tanks = get_tree().get_nodes_in_group("Tanks")
	tanks_count = tanks.size()
	if tanks && tanks_count > 0:
		for tank in tanks:
			for c in tank.get_children():
				if c is LightOccluder2D:
					c.queue_free()
			var collision_shape = tank.get_node("CollisionPolygon2D").polygon
			var occluder_polygon = OccluderPolygon2D.new()
			occluder_polygon.set("polygon", collision_shape)
			var occluder = LightOccluder2D.new()
			occluder.set("occluder", occluder_polygon)
			tank.add_child(occluder)
			occluder.global_position = tank.global_position
			occluder.global_rotation = tank.global_rotation
			occluder.add_to_group("NightMapOccluders")
		occluders_func = "manage_occluders"

func manage_occluders():
	var tanks = get_tree().get_nodes_in_group("Tanks")
	var current_size = tanks.size()
	if current_size > tanks_count:
		create_occluders()

func _process(delta):
	call(occluders_func)