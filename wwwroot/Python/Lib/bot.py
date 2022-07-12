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
