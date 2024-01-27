#basic prototype, allows user to place blocks and play rythm. only has ti-ti set up, but has capability for other rythms
#plays in order placed down
from music21 import stream, meter, note, midi
import pygame

def create_rhythm(rhythm):
    score = stream.Score()
    part = stream.Part()
    part.append(meter.TimeSignature('4/4')) #possibly change time signature at some point?

    for symbol in rhythm:
        if symbol == 'ti-ti':#ti-ti is the only rythm used in this version
            note_ti_ti_1 = note.Note('C4', quarterLength=0.5)
            note_ti_ti_2 = note.Note('C4', quarterLength=0.5)
            part.append([note_ti_ti_1, note_ti_ti_2])

    score.append(part)
    return score

def play_music21_stream(score):
    # Create a StreamPlayer
    player = midi.realtime.StreamPlayer(score)

    # Play the stream in real-time
    player.play()

class block():
    def __init__(self, rythm, pos, image):
        self.rythm = rythm
        self.pos = pos
        self.image = image


pygame.init()
screen = pygame.display.set_mode((500, 500))
running = True


titiImage = pygame.image.load("blockset 1\\titiblock.png")

#define block types


drawlist = []

while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        
        elif event.type == pygame.MOUSEBUTTONDOWN:

            drawlist.append(block('ti-ti', pygame.mouse.get_pos(), titiImage))

        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_p:

                rythm = []
                for j in drawlist:
                    rythm.append(j.rythm)
                rhythm_score = create_rhythm(rythm)
                # Play the generated rhythm
                play_music21_stream(rhythm_score)
                print("done")

    screen.fill('white')
    for i in drawlist:
        screen.blit(i.image, i.pos)
    screen.blit(titiImage, pygame.mouse.get_pos())
    
    pygame.display.flip()


pygame.quit()