# How to build

To build showcase game, i recommand using Unity Addressable system to load data and scene.

1. Add ``Launcher.unity`` to BuildSetting Scene List.
2. Add ``Showcase.unity`` to Addressable Group.
3. Open ``Launcher.unity`` and add ``Showcase.unity``'s address to the `Main Scene Reference` field of ``Launcher``.
4. Click Build.