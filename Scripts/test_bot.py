print("Python Script Loaded!")
centerVector = [0, 0, 0]
centerDistance = 0
centerDirection = 0
throttleValue = 0
rotateValue = 0
canShoot = True
shoot = False
radar = []
output = []


def getCenterVector():
    return centerVector


def getCenterDistance():
    return centerDistance


def getCenterDirection():
    return centerDirection


def getThrottleValue():
    return throttleValue


def setThrottleValue(value):
    global throttleValue
    throttleValue = value


def getRotateValue():
    return rotateValue


def setRotateValue(value):
    global rotateValue
    rotateValue = value


def canFire():
    return canShoot


def fireCannon():
    global shoot
    shoot = True


def checkRadar():
    return radar


def log(value):
    global output
    output.Add(str(value))

class Bot:

    def __init__(self):
        setThrottleValue(1)
        self.reverse = False
        self.count = 0

    def update(self):
        if not self.reverse:
            if getCenterDistance() > 21.5:
                if getCenterDirection() > 0:
                    setRotateValue(1)
                else:
                    setRotateValue(-1)
            else:
                setRotateValue(0)

            self.checkRadar()
        elif self.count < 25:
            self.count += 1
        else:
            self.count = 0
            self.reverse = False
            setThrottleValue(1)

    def checkRadar(self):
        for data in radar:
            if data[0] == "obstacle":
                if data[2] < 8:
                    if 0 <= data[3] < 30:
                        setRotateValue(-0.5)
                    elif -30 < data[3] < 0:
                        setRotateValue(0.5)

            elif data[0] == "bot":
                if -15 <= data[3] < 15 and canFire():
                    fireCannon()
                    log('shooting')

            if data[2] < 2 and -30 <= data[3] < 30:
                setThrottleValue(-0.5)
                if 0 <= data[3] < 30:
                    setRotateValue(1)
                elif -30 < data[3] < 0:
                    setRotateValue(-1)
                self.reverse = True
                break