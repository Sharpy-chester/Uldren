using UnityEditor;

[CustomEditor(typeof(Dialogue))]
public class DialogueEditor : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        SerializedProperty displayTextProperty = serializedObject.FindProperty("displayText");

        SerializedProperty dialogueLinesProperty = serializedObject.FindProperty("dialogueLines");
        SerializedProperty dialogueChoicesNeededProperty = serializedObject.FindProperty("dialogueChoicesNeeded");

        SerializedProperty choice1LinesProperty = serializedObject.FindProperty("choice1Lines");
        SerializedProperty choice1LinesNeededProperty = serializedObject.FindProperty("Choice1LinesNeeded");
        SerializedProperty choice1aLinesProperty = serializedObject.FindProperty("choice1aLines");
        SerializedProperty choice1bLinesProperty = serializedObject.FindProperty("choice1bLines");
        SerializedProperty choice1cLinesProperty = serializedObject.FindProperty("choice1cLines");

        SerializedProperty choice2LinesProperty = serializedObject.FindProperty("choice2Lines");
        SerializedProperty choice2LinesNeededProperty = serializedObject.FindProperty("Choice2LinesNeeded");
        SerializedProperty choice2aLinesProperty = serializedObject.FindProperty("choice2aLines");
        SerializedProperty choice2bLinesProperty = serializedObject.FindProperty("choice2bLines");
        SerializedProperty choice2cLinesProperty = serializedObject.FindProperty("choice2cLines");

        SerializedProperty choice3LinesProperty = serializedObject.FindProperty("choice3Lines");
        SerializedProperty choice3LinesNeededProperty = serializedObject.FindProperty("Choice3LinesNeeded");
        SerializedProperty choice3aLinesProperty = serializedObject.FindProperty("choice3aLines");
        SerializedProperty choice3bLinesProperty = serializedObject.FindProperty("choice3bLines");
        SerializedProperty choice3cLinesProperty = serializedObject.FindProperty("choice3cLines");

        EditorGUILayout.PropertyField(displayTextProperty);
        EditorGUILayout.PropertyField(dialogueLinesProperty, true);
        EditorGUILayout.PropertyField(dialogueChoicesNeededProperty);

        int dialogueLinesNeeded = dialogueChoicesNeededProperty.intValue;

        if (dialogueLinesNeeded >= 1)
        {
            EditorGUILayout.PropertyField(choice1LinesProperty, true);
            EditorGUILayout.PropertyField(choice1LinesNeededProperty);

            int choice1LinesNeeded = choice1LinesNeededProperty.intValue;

            if (choice1LinesNeeded >= 1)
            {
                EditorGUILayout.PropertyField(choice1aLinesProperty, true);
            }

            if (choice1LinesNeeded >= 2)
            {
                EditorGUILayout.PropertyField(choice1bLinesProperty, true);
            }

            if (choice1LinesNeeded >= 3)
            {
                EditorGUILayout.PropertyField(choice1cLinesProperty, true);
            }
        }
        if (dialogueLinesNeeded >= 2)
        {
            EditorGUILayout.PropertyField(choice2LinesProperty, true);
            EditorGUILayout.PropertyField(choice2LinesNeededProperty);

            int choice2LinesNeeded = choice2LinesNeededProperty.intValue;

            if (choice2LinesNeeded >= 1)
            {
                EditorGUILayout.PropertyField(choice2aLinesProperty, true);
            }

            if (choice2LinesNeeded >= 2)
            {
                EditorGUILayout.PropertyField(choice2bLinesProperty, true);
            }

            if (choice2LinesNeeded >= 3)
            {
                EditorGUILayout.PropertyField(choice2cLinesProperty, true);
            }
        }

        if (dialogueLinesNeeded >= 3)
        {
            EditorGUILayout.PropertyField(choice3LinesProperty, true);
            EditorGUILayout.PropertyField(choice3LinesNeededProperty);

            int choice3LinesNeeded = choice3LinesNeededProperty.intValue;

            if (choice3LinesNeeded >= 1)
            {
                EditorGUILayout.PropertyField(choice3aLinesProperty, true);
            }

            if (choice3LinesNeeded >= 2)
            {
                EditorGUILayout.PropertyField(choice3bLinesProperty, true);
            }

            if (choice3LinesNeeded >= 3)
            {
                EditorGUILayout.PropertyField(choice3cLinesProperty, true);
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}
