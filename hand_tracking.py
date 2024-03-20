import cv2
from cvzone.HandTrackingModule import HandDetector
import socket

width, height = 1280, 720

cap = cv2.VideoCapture(0)
cap.set(3, 1280)
cap.set(4, 720)


detector = HandDetector(detectionCon=0.8, maxHands=1)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
server_address_port = ("127.0.0.1", 5511)

def main():
    while True:
        data = []
        success, img = cap.read()
        hands, img = detector.findHands(img)

        if hands:
            hand = hands[0]
            lm_list = hand["lmList"]

            for lm in lm_list:
                data.extend([lm[0], height - lm[1], lm[2]])
                sock.sendto(str.encode(str(data)), server_address_port)


        cv2.imshow("Image", img)
        cv2.waitKey(1)

if __name__ == "__main__":
    main()