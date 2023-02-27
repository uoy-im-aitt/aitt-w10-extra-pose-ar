# Extra Practical: Prototyping Pose-based AR with an IMU 

In the Augmented Reality (AR) lecture, we took a look at how AR interfaces overlay digital content onto the physical world. In this practical, we are going to learn to implement some of the AR techniques from the lecture in Unity. We will be implementing one of these techniques using your Android tablets.

To get started, make a copy of this git repository in your personal GitHub account by pressing the ```Use This Template``` button at the top right of this pace.

## Task 1: Displaying the Camera Image

In the lecture we learned about a range of techniques for displaying digital content over the real world in AR experiences. Today, you are going to implement an AR experience using the Mobile Device Overlay technique. You should recall that this technique displays digital content over the real world by overlaying it onto a camera image that’s shown on the screen of a mobile device.

To implement this display technique in Unity, we first need to display a camera image in a Unity scene. Unity allows us to grab an image from a device’s camera and display it onto a ```RawImage UI``` component. You can create a simple app that displays a camera image in full screen (what we need) by completing following steps:

1. Create a UI Canvas containing a ```RawImage``` component. This component should have its ```RectTransform``` configured so that it is stretched to fill the whole of the screen.
2. Add the script ```WebcamRender.cs``` (found in ```Assets/PracticalAssets```) to the GameObject containing the ```RawImage``` component. This instructs Unity to render the image from the device’s camera onto your RawImage (take a look at the code – it’s pretty simple).
3. Once you’ve followed these steps, build and run the your scene on your Android tablet. The camera image from the device’s rear facing camera should fill the whole screen.

## Task 2: Overlaying Some Digital Content into the World

Once we’ve got a camera image of the world showing on our mobile device screen, the next thing we need to do is to overlay some digital content onto it. In Unity this is easy to do. We simply add some game objects into our scene and then configure the Canvas containing our camera image to always be displayed behind them.

To get started with this task, add the ```MewPokemon``` model into your scene and set its transform position to be the center of the world (i.e. ```[0, 0, 0]```). Once you’ve done this, configure your Canvas so that it displays behind the model by completing the following steps. 

1. Set the Render Mode of the Canvas to ```Screen Space – Camera```
2. Drag the ```MainCamera``` GameObject from the hierarchy into the ```Render Camera``` box in the inspector

Once you’ve done this, build and run your screen on your Android tablet. You should see the 3D model of the Pokémon overlaid onto the camera image of the world.

## Task 3: Basic Registration with Pose Tracking

The problem with the experience we’ve created so far is that the Pokémon model is always positioned in the middle of he camera image. It would be nice if we could make the Pokémon remain in the same position in the world when we move the camera, to give a sense that its actually inhabiting the space. We saw a technique in the lecture to achieve this using the pose sensor available in the device. By orienting the virtual camera that’s used to render the Pokémon based on the orientation of the device, we can make it appear to remain in (roughly) the same position in space when the camera moves.

In this task, you should implement this basic registration approach in Unity by Adding the Devicepose.cs script (found in Assets/PracticalAssets) onto the MainCamera game object. Before doing this, open up the script and look at how it works. You can see that it simply uses the orientation of the device from the gyro to control the rotation of the camera, and then applies a couple of additional rotations to make the orientation align with the camera image.

Once you’ve done this, build and run your screen on your Android tablet. Hold up the device and rotate it to point in different directions until you find the Pokémon. Once you’ve found the Pokémon make some relatively small changes to the orientation of the device and observe how the Pokémon remains in (roughly) the same position in space.
