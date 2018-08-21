extends CenterContainer

var position_relative_to_player = Vector2(0, 0)
var player_name setget set_name

func set_name(value):
	$Label.text = value
	player_name = value

func _ready():
	$Label.text = get_parent().player_name
	set_as_toplevel(true)

func _process(delta):
	rect_global_position = get_parent().global_position - rect_size / 2 + position_relative_to_player
