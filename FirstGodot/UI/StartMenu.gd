extends Control

func _on_play_button_pressed():
	var result = get_tree().change_scene_to_file("res://Scenes/world.tscn")
	if result != OK:
		push_error("Failed to load world scene: %s" % result)

func _on_quit_button_pressed():
	get_tree().quit()
