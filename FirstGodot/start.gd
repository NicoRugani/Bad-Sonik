extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_button_pressed():
	# Start a new game by loading the world scene.
	get_tree().change_scene_to_file("res://world.tscn")


func _on_button_2_pressed():
	# Quit from the start menu.
	get_tree().quit()
