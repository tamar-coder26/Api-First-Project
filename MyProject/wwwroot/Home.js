
const signIn = async () => {

    const postData = {
        useremail: document.querySelector("#useremail").value,
        firstName: document.querySelector("#firstName").value,
        lastName: document.querySelector("#lastName").value,
        password: document.querySelector("#password").value
    }

    const response = await fetch('api/Users' , {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    })
    if (response.ok)
        alert("user succsesfuly added");
    else
        alert("error, try again");
}

const LogIn = async () => {
    try {
        const postData2 = {
            logemail: document.querySelector("#logemail").value,
            logpassword: document.querySelector("#logpassword").value
        }
        const response2 = await fetch('api/Users/Login', {
            method: 'POST',
            headers: { 'content-Type': 'application/json' },
            body: JSON.stringify(postData2)
        })
        if (response2.ok)
        {
            const dataPost = await response2.json();
            console.log(dataPost.stringify)
            sessionStorage.setItem("currentUser", JSON.stringify(dataPost));
            alert("user succsesfuly found")
        }            
        else
            alert("error of login, try again");
    }
    catch (e) { alert("error"); }
}
const checkPass = async () => {
    const password = document.querySelector("#password").value
    console.log("hi3")
    try {
        if (password == '') {console.log("error- empty") }
        const responsepass = await fetch('api/Passwords', {

            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(password)
        })
        console.log("hi2")

        if (responsepass.ok)
        {
            console.log("hi")
            const progress = document.querySelector("#progress")
            console.log("hi4")
            progress.value = await responsepass.json()
        }
        else
        { throw new(responsepass.status) }

    }
    catch (e) {
        console.log(e.message)
    }
}
