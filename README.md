## Simple Event Tracker

In this small prototype, an event tracker is created by the usage of ScriptableObjects in Unity.

### Requirements

This was created in Unity 2018.3.8f1, however it should work in any version of the engine. The UI used in the prototype is the UGUI that was introduced in Unity 4.6 but to get the tracker to work you can use any version.

It must be noted that .Net 4.x is used in this scenario which results in the usage of some of the features that are not available in .Net 3.5. These are in a few lines for better readability and can be changed to the "traditional" way without changing the way the prototype works.

### Installation

Since this is a project, a download is enough to open the project in Unity itself.

### About

This was created as a small test for upcoming projects of GearEight Games where the tracking of user actions (for e.g. achievements or stats) may be required.

Feel free to use the code or get inspired by it.

### Usage

The tracker consists of two objects the tracker and the tracked event. The tracker references all events and updates its internal values accordingly. A file is created to store the assigned values and gets reloaded on the start of the application.
The tracked event is a simple asset that can be added to any script and even a UnityEvent (like a button) to update a value.

### Remarks

**On the usage of `System.String` as an identifier**  
The string was chosen as an identifier for two reasons:
1. It is easy to understand and manipulate for designers.
2. It gets hashed by the dictionary and should not impact the performance much when updating the values. No actual string comparisons are used.

It could be replaced by a `System.Enum` or another numeric identifier, however they are not as easily recognizable as strings and the designer cannot add or remove new members to the enumeration without touching code.

### License

This work is licensed under the MIT license. See the [LICENSE](LICENSE) file for details.