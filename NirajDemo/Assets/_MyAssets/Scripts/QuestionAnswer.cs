using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;
//using Firebase.Auth;

public class QuestionAnswer : MonoBehaviour
{

    public Text usernameInput, passwordInput;

    //private Player data;

    private string DATA_URL = "https://friendlychat-23158.firebaseio.com/";

    private DatabaseReference databaseReference;
    // Start is called before the first frame update
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl(DATA_URL);

        databaseReference = FirebaseDatabase.DefaultInstance.RootReference;

        LoadData();
    }

    //public void SaveData()
    //{
    //    if (usernameInput.Equals("") && passwordInput.Equals(""))
    //    {
    //        return;
    //    }

    //    data = new Player(usernameInput.text, passwordInput.text);

    //    string jsonData = JsonUtility.ToJson(data);

    //    databaseReference.Child("Users" + Random.Range(0, 100000)).SetRawJsonValueAsync(jsonData);
    //}

    public void LoadData()
    {

        FirebaseDatabase.DefaultInstance
            .GetReference("Questions")
            .GetValueAsync().ContinueWith(task => {
                if (task.IsFaulted)
                {
                    print("Task is Faulted");
                }
                if (task.IsCompleted)
                {
                    DataSnapshot dataSnapshot = task.Result;
                    string playerdata = dataSnapshot.Child("QID1").Child("question").GetRawJsonValue();
                    //print(playerdata);
                    string optionVal = dataSnapshot.Child("QID1").Child("option1").GetRawJsonValue();
                    print(playerdata + "___" + optionVal);
                }
            });
        //FirebaseDatabase.DefaultInstance.GetReferenceFromUrl(DATA_URL)
        //    .GetValueAsync().ContinueWith(task => {
        //        if (task.IsCanceled)
        //        {

        //        }

        //        if (task.IsFaulted)
        //        {

        //        }

        //        if (task.IsCompleted)
        //        {
        //            //Firebase.Auth.FirebaseUser user = Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser;
        //            //if (user != null)
        //            //{
        //            //    string name = user.UserId;
        //            //    print("user is valid" + name);
        //            //} else
        //            //{
        //            //    print("user is null");
        //            //}
        //            DataSnapshot dataSnapshot = task.Result;

        //            string playerData = dataSnapshot.GetRawJsonValue();

        //            //For single player valure retrive
        //            //Player m = JsonUtility.FromJson<Player>(playerData);

        //            foreach (var child in dataSnapshot.Children)
        //            {
        //                string t = child.GetRawJsonValue();

        //                //Convert into single data
        //                //Player extractedData = JsonUtility.FromJson<Player>(t);

        //                //print("The Player username is: " + extractedData.username);
        //                print("The Player password i: " + extractedData.password);


        //                //For full user record
        //                //print("Date is " + t);
        //            }
        //        }
        //    });
    }

    // Update is called once per frame
    void Update()
    {

    }
}

