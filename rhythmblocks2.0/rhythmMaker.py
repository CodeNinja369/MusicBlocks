from music21 import stream, meter, note, midi
def createRhythm(rhythm):
    score = stream.Score()
    part = stream.Part()
    part.append(meter.TimeSignature('4/4'))

    for symbol in rhythm:
        match symbol:
            case "ta":
                note_ta = note.Note('C4', quarterLength=1.0) #length of notes create individual pieces of rythm. think of 1 as a quarter and 0.5 as an 8th
                part.append(note_ta)
            case "ta-a":
                note_ta_a = note.Note('C4', quarterLength = 2.0)
                part.append(note_ta_a)
            case "ti-ti":
                note_ti_ti_1 = note.Note('C4', quarterLength=0.5)
                note_ti_ti_2 = note.Note('C4', quarterLength=0.5)
                part.append([note_ti_ti_1, note_ti_ti_2])
            case "tika-tika":
                note_tika_tika = note.Note('C4', quarterLength=0.25)
                note_tika_tika2 = note.Note('C4', quarterLength=0.25)
                note_tika_tika3 = note.Note('C4', quarterLength=0.25) 
                note_tika_tika4 = note.Note('C4', quarterLength=0.25)
                part.append([note_tika_tika, note_tika_tika2, note_tika_tika3, note_tika_tika4])
            case "rest":
                rest = note.Rest(quarterLength=1.0)
                part.append(rest)

    score.append(part)
    return score

def playMusic21Stream(score):
    # Create a StreamPlayer
    player = midi.realtime.StreamPlayer(score)

    # Play the stream in real-time
    player.play()