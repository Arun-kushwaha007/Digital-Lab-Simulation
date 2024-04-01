from kivymd.app import MDApp
from kivymd.uix.label import MDLabel
from cvzone.HandTrackingModule import HandDetector
import cv2
import socket
import mediapipe as mp


class Main_App(MDApp):
    
    def track_hands(self):
        cap = cv2.VideoCapture(0)
        cap.set(3, 1280)
        cap.set(4, 720)
        success, img = cap.read()
        h, w, _ = img.shape
        detector = HandDetector(detectionCon=0.8, maxHands=2)

        sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        serverAddressPort = ("127.0.0.1", 5055)

        while True:
            # Get image frame
            success, img = cap.read()
            # Find the hand and its landmarks
            hands, img = detector.findHands(img)  # with draw
            # hands = detector.findHands(img, draw=False)  # without draw
            data = []

            if hands:
                # Hand 1
                hand = hands[0]
                lmList = hand["lmList"]  # List of 21 Landmark points

                # Calculate size of hand in pixels
                x_min, y_min = min(lmList, key=lambda x: x[0])[0], min(lmList, key=lambda x: x[1])[1]
                x_max, y_max = max(lmList, key=lambda x: x[0])[0], max(lmList, key=lambda x: x[1])[1]
                hand_width = x_max - x_min
                hand_height = y_max - y_min
                hand_size = max(hand_width, hand_height)

                for lm in lmList:
                    data.extend([lm[0], h - lm[1], lm[2]])
                data.append(hand_size)

                sock.sendto(str.encode(str(data)), serverAddressPort)

            # Display
            cv2.imshow("Image", img)
            cv2.waitKey(1)

    def build(self):
        # Call the function to start hand tracking
        self.track_hands()

if __name__ == "__main__":
    Main_App().run()
