README_SD_KohakuChanz.TXT

SD Kohaku-chan's O-usu Academy Summer & Winter Uniform Model Ver 1.1.0

2023/02/15 Unity Technologies Japan

History:
Ver. 1.1.0 2023/02/15 Replaced shaders with Unity Toon Shader and reconfigured.
Ver. 1.0.1 2016/01/29 Fixed Yuko's animator (eye_close was updated for Yuko)
Ver. 1.0.0 2016/01/10 First release

Distribution License:
This digital asset data is released based on the "Unity-Chan License Agreement (UCL)" (the latest version at the time of distribution is UCL 2.02).
Please refer to the following for the latest version of the "Unity-Chan License Agreement".

Unity-chan Licensing Terms and Conditions, Summary
https://unity-chan.com/contents/guideline/

Unity-chan Licensing Terms and Conditions, Official Text
https://unity-chan.com/contents/license_jp/

Character Usage Guidelines (FAQ)
https://unity-chan.com/contents/faq/

In particular, the FAQ explains in detail what creators "can" and "cannot" do under this license, giving specific examples.
Please be sure to read the FAQ before use.


Usage Environment:
Unity Toon Shader can be used in Built-In, URP, or HARP environments.
For details, please refer to the following manual. The installation method is also described in the manual.
https://docs.unity3d.com/Packages/com.unity.toonshader@latest

The original data for this digital asset data was created in Unity 5.2.3 f1.
The conversion process to Unity Toon Shader was done in the BuiltIn environment of Unity 2020.3.44 f1.


How to use:
1. create a new project with Unity 2020.3.x f1 or later and install Unity Toon Shader from the package manager in advance.
   For details on how to install Unity Toon Shader, please refer to the manual link above and find the Installation section.

2. D&D this Unitypackage into the project window.
   Confirm that it is successfully extracted and a new UnityChan folder is created under the Assets folder.

3. Unity Toon Shader supports all Unity rendering pipelines: BuiltIn, URP, and HDRP.
   When you open the sample scene, if it is BuiltIn or URP, the character is displayed as it is.
   For HDRP, the model may appear black immediately after opening the sample scene.
   In this case, select Directional Light in the sample scene once.
   When the character is displayed correctly, save the scene. Thereafter, the character will be displayed correctly immediately after opening the sample scene.

Sample Scenes:
\Assets\UnityChan\SD_Kohaku_chanz\Scenes There are sample scenes for each model below.

SD Misaki Fujiwara - Ko-Usui Academy Summer School Uniform Model Sample Scene
Misaki_sum.unity

SD Misaki Fujiwara - Ko-Usui Academy Winter Uniform Model Sample Scene
Misaki_win.unity

SD Emberu Otori (Unity-chan) - KOUUSAI Academy Summer School Uniform Model Sample Scene
UTC_sum.unity

SD Emberu Otori (Unity-chan) - KOUUSAI Academy Winter Uniform Model Sample Scene
UTC_win.unity

SD Yuko Kanbayashi - Ko-Usui Academy Summer Uniform Model Sample Scene
Yuko_sum.unity

SD Yuko Kanbayashi - Ko-Usui Academy Winter Uniform Model Sample Scene
Yuko_win.unity


Components attached to the characters in the sample scenes
Each scene has one of the following character models: Amber, Misaki, or Yuko.
The main components attached to the character model are as follows.

Animator Component
　This is an Animator component in Mecanim/Humanoid format.
　The Animator controller is different for each character.

Idle Changer Component
　This component switches the animation.

Face Update component
　This component switches faces.

Auto Blink for SD Components
　This component performs automatic blinking.

Spring Manager Component
　This component controls sway (dynamics).

Random Wind component
　This component makes the shaking object sway as if it were blowing in the wind, even when the model is at rest.
　It is initially inactive.

IK Look At component
　This component follows the line of sight by moving the Target.
　It is initially inactive.


Contact information for inquiries:

Unity Technologies Japan, G.K.
unity-chan@unity3d.com

Unity-chan Official Site
https://unity-chan.com/
