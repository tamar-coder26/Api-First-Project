console.log("hi")
const useremailUpdate = document.querySelector("#useremailUpdate");
const firstNameUpdate = document.querySelector("#firstNameUpdate");
const lastNameUpdate = document.querySelector("#lastNameUpdate");
const passwordUpdate = document.querySelector("#passwordUpdate");

const data = JSON.parse(sessionStorage.getItem("currentUser"));
console.log(data)
useremailUpdate.value = data.useremail;
firstNameUpdate.value = data.firstName;
lastNameUpdate.value = data.lastName;
passwordUpdate.value = data.password;



const Update = async () => {
    const userupdate = {
        useremail: document.querySelector("#useremailUpdate").value,
        firstName: document.querySelector("#firstNameUpdate").value,
        lastName: document.querySelector("#lastNameUpdate").value,
        password: document.querySelector("#passwordUpdate").value,
        Id: data.id
    };
    console.log(userupdate.stringify)
    const responsePut = await fetch('api/Users/'+data.id,
        {
            method : 'PUT',
            headers: { 'content-type': 'application/json' },
            body: JSON.stringify(userupdate)
        });
    if (responsePut.ok)
        alert("this user is updated")
    else alert("error in updating user")
}