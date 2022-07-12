import math
import random
import bot


class Bot:

    def __init__(self):
        bot.setThrottleValue(1)
        self.reverse = False
        self.count = 0

    def update(self):
        if not self.reverse:
            if bot.getCenterDistance() > 21.5:
                if bot.getCenterDirection() > 0:
                    bot.setRotateValue(1)
                else:
                    bot.setRotateValue(-1)
            else:
                bot.setRotateValue(0)

            self.checkRadar()
        elif self.count < 25:
            self.count += 1
        else:
            self.count = 0
            self.reverse = False
            bot.setThrottleValue(1)

    def checkRadar(self):
        for data in bot.checkRadar():
            if data[0] == "obstacle":
                if data[2] < 8:
                    if 0 <= data[3] < 30:
                        bot.setRotateValue(-0.5)
                    elif -30 < data[3] < 0:
                        bot.setRotateValue(0.5)

            elif data[0] == "bot":
                if -15 <= data[3] < 15 and bot.canFire():
                    bot.fireCannon()
                    bot.log('shooting')

            if data[2] < 2 and -30 <= data[3] < 30:
                bot.setThrottleValue(-0.5)
                if 0 <= data[3] < 30:
                    bot.setRotateValue(1)
                elif -30 < data[3] < 0:
                    bot.setRotateValue(-1)
                self.reverse = True
                break

