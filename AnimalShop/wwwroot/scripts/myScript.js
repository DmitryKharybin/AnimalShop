"use strict"; // strict mode do not allow the use of undeclared variables


document.addEventListener("DOMContentLoaded", startup);
let colorSwapBtn;


function startup() {

    colorSwapBtn = document.querySelector(".color_swapper");

    //If Dark mode was activated then on page refresh , change to dark mode 
    if (localStorage.getItem("dark_mode")) {
        colorSwap();
    }

    let fileUploadInput = document.querySelector(".file_upload");
    let animalCategorySelect = document.querySelector(".my_form");
    let commentSubmitBtn = document.querySelector(".submit_comment");

    if (commentSubmitBtn !== null) {
        commentSubmitBtn.addEventListener("click", submitComment);
    }

    //Not all pages include a file upload folrm , thus it may be null
    if (fileUploadInput != null) {
        fileUploadInput.addEventListener("change", updateImageDisplay);
    }

    //Not all pages include a category select , thus it may be null
    if (animalCategorySelect != null) {
        animalCategorySelect.addEventListener("change", animalTypeSelectOnChange);
    }

    colorSwapBtn.addEventListener("click", colorSwap);

}





//On change of category selection , submit category selection
function animalTypeSelectOnChange() {
    document.querySelector(".my_form").submit();
}




//Submit comment for animal (Including client side validation)
function submitComment() {
    let animalId = document.querySelector("#animal_id").value;
    let inputComment = document.querySelector(".comment_area");
    let errorSpan = document.querySelector(".error_text");
    let commentList = document.querySelector(".comment_list");
    let newComment = document.createElement("li");



    //Client side validation : If comment is empty then don't send POST request & let user know that comment is invalid
    if (inputComment.value === "") {
        errorSpan.innerText = "Comment can not be empty!"
    } else {

        newComment.innerText = inputComment.value;

        $.ajax({
            type: "POST",
            url: "/Shop/AddComment",
            data: {
                Note: inputComment.value, animalId: animalId
            },
            success: function () {
                errorSpan.innerText = "";
                commentList.appendChild(newComment);
                inputComment.value = "";
            },
            error: function () {
                errorSpan.innerText = "Comment Not valid";
                console.log("Comment was not added");
            }

        });
    }


}







//Will swap dark/light mode on elements present on all pages & check what page is displayed
// swap The unique element's on current page color mode
function colorSwap() {


    document.body.classList.toggle("dark");

    let swappable_navbar = document.querySelector(".navbar"); //All
    let navbar_items = document.querySelector(".navbar_items");//All
    let layoutImage = document.querySelector(".layout_image");//All

    //All Pages share a hidden element with same id , value changes
    let PageIdentifier = document.querySelector("#page_identifier");



    navbar_items.classList.toggle("bg-dark");
    swappable_navbar.classList.toggle("navbar-dark");
    swappable_navbar.classList.toggle("bg-dark");



    if (navbar_items.classList.contains("bg-dark")) {
        layoutImage.src = "/Resources/DarkAkitaLogo.png";
        localStorage.setItem("dark_mode", "true");

        colorSwapBtn.classList.remove("bi-sun");
        colorSwapBtn.classList.add("bi-moon");

    }
    else {
        layoutImage.src = "/Resources/AkitaLogo.png";
        localStorage.removeItem("dark_mode");
        colorSwapBtn.classList.remove("bi-moon");
        colorSwapBtn.classList.add("bi-sun");
    }



    //Check What page is currently displayed and change it accordingly
    //The hidden input in every page help identify each page
    if (PageIdentifier.value == "main_menu") {
        swapMainMenu();
    }

    else if (PageIdentifier.value == "administrator") {
        swapAdministrator();
    }

    else if (PageIdentifier.value == "animal_details") {
        swapAnimalDetails();
    }

    else if (PageIdentifier.value == "edit_animal") {
        swapEditAnimal();
    }

    else if (PageIdentifier.value == "create_animal") {
        swapCreateAnimal();
    }

    else if (PageIdentifier.value == "catalog") {
        swapCatalog();
    }
}




//Swap Every page individually (Modular solution)

function swapMainMenu() {

    let main_menu_header = document.querySelector("h2");//MainMenu



    toggleClass(".card", "bg-dark");


    main_menu_header.classList.toggle("bg-dark");


}

function swapAdministrator() {
    let animalDetailsForm = document.querySelector("form");//Create Animal, Edit Animal, Administrator(select), Catalog(select)



    toggleClass("table", "dark");

    animalDetailsForm.classList.toggle("dark");

}

function swapAnimalDetails() {
    let comment_section = document.querySelector(".scrollable");//Animal Details



    toggleClass("table", "dark");


    comment_section.classList.toggle("dark");


}

function swapEditAnimal() {
    let form = document.querySelector("form");//Create Animal, Edit Animal, Administrator(select), Catalog(select)


    form.classList.toggle("dark");

}

function swapCreateAnimal() {
    let form = document.querySelector("form");//Create Animal, Edit Animal, Administrator(select), Catalog(select)


    form.classList.toggle("dark");
}

function swapCatalog() {
    let form = document.querySelector("form");//Create Animal, Edit Animal, Administrator(select), Catalog(select)



    toggleClass(".card", "bg-dark");

    form.classList.toggle("dark");


}


//Helper function
//Insert parameter for queryselector(element) and className you would like to toggle
//Meant for class That multiple elements have
function toggleClass(element, className) {

    let inputElement = document.querySelectorAll(element);

    for (let i = 0; i < inputElement.length; i++) {
        inputElement[i].classList.toggle(className);
    }
}



//Update display image in animal Form (Edit & Create new) according to file upload
function updateImageDisplay() {
    const preview = document.querySelector(".preview");
    const errorMessage = document.createElement("p");

    //The file upload element
    const curFiles = this.files;

    //Protection against possible null input
    if (curFiles !== null) {

        for (let file of curFiles) {



            if (file.length === 0) {

                errorMessage.textContent = "No file currently selected for upload";


                preview.appendChild(errorMessage);
            } else {

                if (validFileType(file)) {

                    preview.innerHTML = "";

                    let image = document.createElement("img");
                    image.src = URL.createObjectURL(file);
                    image.className = "rounded float-left";

                    preview.appendChild(image);
                } else {
                    preview.innerHTML = "";
                    errorMessage.textContent = "Please Choose Png/Jpg image and try again";
                    //If file is not png/jpeg then it will be removed from file upload field!
                    this.value = null;
                    preview.appendChild(errorMessage);
                }

            }
        }
    }
}

//Array That include The file types i allow to be uploaded (Png,Jpeg)
const fileTypes = [
    "image/jpeg",
    "image/png",
    "image/jpeg"
];




//Check if The file Extension is valid
function validFileType(file) {

    console.log("file type:" + file.type);
    return fileTypes.includes(file.type);
}





