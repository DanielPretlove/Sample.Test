import {useState, useEffect} from 'react';
import {UserView} from './UserView';
import {UserEdit} from './UserEdit';
import {UserDelete} from './UserDelete';


export default function UserList() {
  const [user, setUser] = useState([]);
  const [view, setView] = useState(false);   
  const [create, setCreate] = useState(false);   
  const [edit, setEdit] = useState(false);   
  const [del, setDelete] = useState(false); 
  
  
  async function fetchUsers() {
    const response = await fetch("https://localhost:44448/api/User");
    const data = await response.data;
    setUser(data);
  }

   useEffect(() => {
    fetchUsers();
   }, [])

   const ViewDialog = () => {
    setView(!view);
   }

   const CreateDialog = () => {
    setCreate(!create);
   }

   const EditDialog = () => {
    setEdit(!edit);
   }

   const DeleteDialog = () => {
    setDelete(!del);
   }
   

  return (
    <div>
      <button onClick={() => CreateDialog()}>Create New</button>
      <table className="table table-striped" aria-labelledby="tableLabel">
        <thead>
          <tr>
            <th>First Name</th>
            <th>Last Name</th>
            <th>Email</th>
            <th>Actions</th>
          </tr>
        </thead>
        <tbody>
          {user.map((u => {
            return (
              <>
                <tr>{u.FirstName}</tr>
                <tr>{u.LastName}</tr>
                <tr>{u.Email}</tr>
              </>
            )
          }))}
          <div className="actions">
            <tr onClick={() => ViewDialog()}>View</tr>
            <tr onClick={() => EditDialog()}>Edit</tr>
            <tr onClick={() => DeleteDialog()}>Delete</tr>
          </div>
        </tbody>
          {view ? <UserView /> : ""}
          {edit ? <UserEdit /> : ""}
          {del ? <UserDelete /> : ""}
      </table>
    </div>

  );
}
