import pygame.midi
import time

def play_midi_note(note, duration):
    # Initialize Pygame MIDI
    pygame.midi.init()

    # Open a Pygame MIDI output device
    output_device = pygame.midi.Output(0)
    output_device.set_instrument(0)  # Select the instrument (0 is often piano)

    # Note On event
    output_device.note_on(note, velocity=127)
    time.sleep(duration)  # Hold the note for the specified duration

    # Note Off event
    output_device.note_off(note, velocity=127)

    # Close the MIDI output device
    del output_device
    pygame.midi.quit()

# Example: Play middle C (note number 60) for 1 second
note_to_play = 60
note_duration = float(1)  # in seconds
play_midi_note(note_to_play, note_duration/4)
play_midi_note(note_to_play, note_duration/4)
