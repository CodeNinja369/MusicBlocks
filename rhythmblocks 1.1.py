#adds set positions for blocks, limits number of blocks to four, adds rest and ta
#plays from left to right
#better naming conventions (camelCase)

#imports functions from rhythm maker rather than re-writing
from rhythmMaker import playMusic21Stream, createRhythm
import pygame


class blockType():
    def __init__(self, rhythm, image):
        self.rhythm = rhythm
        self.image = image

class baseBlock():
    def __init__(self, length):
        self.length = length
        array = []
        for i in range(length):
            array.append(None)
        self.array = array
        self.arrayPos = [pygame.Rect(0,0,121,110), pygame.Rect(125,0,121,110), pygame.Rect(250,0,121,110), pygame.Rect(375,0,121,110)]

pygame.init()
screen = pygame.display.set_mode((500, 500))
running = True

#blockset one is just filler for until i can get an actual artist to draw blocks
titiImage = pygame.image.load("blockset 1\\titiblock.png")
taImage = pygame.image.load("blockset 1\\tablock.png")
restImage = pygame.image.load("blockset 1\\restblock.png")

drawlist = []
base = baseBlock(4)

#define block types
titi = blockType('ti-ti', titiImage)
ta = blockType('ta', taImage)
rest = blockType('rest', restImage)

currentBlockType = titi

while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        
        elif event.type == pygame.MOUSEBUTTONDOWN:
            print(pygame.mouse.get_pos())
            for j, i in enumerate(base.arrayPos):
                if i.collidepoint(pygame.mouse.get_pos()):
                    base.array[j] = currentBlockType
        
        elif event.type == pygame.KEYDOWN:
            if event.key == pygame.K_p:

                rhythm = []
                for j in base.array:
                    if j!= None:
                        rhythm.append(j.rhythm)
                rhythm_score = createRhythm(rhythm)
                # Play the generated rhythm
                playMusic21Stream(rhythm_score)
                print("done")
            if event.key == pygame.K_1:
                currentBlockType = ta
            if event.key == pygame.K_2:
                currentBlockType = titi
            if event.key == pygame.K_3:
                currentBlockType = rest

    screen.fill('white')
    
    for i, k in enumerate(base.array):
        if k!=None:
            screen.blit(k.image, base.arrayPos[i])
    screen.blit(currentBlockType.image, pygame.mouse.get_pos())
    
    pygame.display.flip()


pygame.quit()