import cv2
from cvzone.HandTrackingModule import HandDetector
import asyncio
import websockets

width, height = 1280, 720

cap = cv2.VideoCapture(0)
cap.set(3, 1280)
cap.set(4, 720)

detector = HandDetector(maxHands=1, detectionCon=0.5)

async def main():
    async with websockets.connect('ws://localhost:8080') as websocket:
        while True:
            data = []
            success, img = cap.read()
            hands, img = detector.findHands(img)

            if hands:
                hand = hands[0]
                lm_list = hand["lmList"]
                for lm in lm_list:
                    data.extend([lm[0], height - lm[1], lm[2]])

                await websocket.send(str(data))

            cv2.imshow("Image", img)
            if cv2.waitKey(1) == ord('q'):
                break

async def run_main_forever():
    while True:
        await main()

asyncio.run(run_main_forever())