// using UnityEngine;

// public class serializer
// {

//       #region vector
//       static void VectorSerialzer(string path, Vector3 v)
//       {

//             using (FileStream fs = File.Open(path, FileMode.Create))
//             {
//                   Byte[] By = new Byte[3 * 4];
//                   float a = v.x;
//                   BitConverter.GetBytes(v.x).CopyTo(By, 0);
//                   BitConverter.GetBytes(v.y).CopyTo(By, 4);
//                   BitConverter.GetBytes(v.z).CopyTo(By, 8);
//                   fs.Write(By);
//             }
//       }
//       static Vector3 VectorDeSerialzer(string path)
//       {
//             var v = new Vector3();
//             using (FileStream fs = File.Open(path, FileMode.Open))
//             {
//                   Byte[] bufer = new Byte[fs.Length];
//                   fs.Read(bufer, 0, 11);
//                   v.x = BitConverter.ToSingle(bufer, 0);
//                   v.y = BitConverter.ToSingle(bufer, 4);
//                   v.z = BitConverter.ToSingle(bufer, 8);
//             }

//             return v;
//       }
//       #endregion


// }