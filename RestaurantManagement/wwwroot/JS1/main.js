

/*-----------------
 toggle navbar
-------------------*/



const navToggler = document.querySelector(".nav-toggler");
navToggler.addEventListener("click", toggleNav);

// console.log(navToggler)

function toggleNav(){
    navToggler.classList.toggle("active");
    document.querySelector(".nav").classList.toggle("open");


}



// close Nav bar
document.addEventListener("click", function(e){
    if(e.target.closest(".nav-item")){
        toggleNav();
    }
})




/* -----------------
Sticky header
-------------------*/

window.addEventListener("scroll",function(){
    if(this.pageYOffset > 60){
        document.querySelector(".header").classList.add("sticky");
        text = document.querySelector(".resName");
        text.style.color = "#eaa023"
    }
    else{
        document.querySelector(".header").classList.remove("sticky");
        text = document.querySelector(".resName");
        text.style.color = "white"
        
    }
});


/*----------------------menu tabs ----------------------------*/

const menuTabs = document.querySelector(".menu-tabs");
menuTabs.addEventListener("click",function(e){
    if(e.target.classList.contains("menu-tab-item") && !e.target.classList.contains("active")){
        const target = e.target.getAttribute("data-target");
        menuTabs.querySelector(".active").classList.remove("active");
        e.target.classList.add("active");
        const menuSection = document.querySelector(".menu-section");
        menuSection.querySelector(".menu-tab-content.active").classList.remove("active");
        menuSection.querySelector(target).classList.add("active");
    }
});



/*-----------------------------Login Registration------------------------------*/

/*const registerbtn = document.querySelector("#register-button");
registerbtn.addEventListener("click", function () {
    const register = document.querySelector("#register");
    const login = document.querySelector("#login");

   *//* register.classList.remove("d-none");
    login.classList.add("d-none");*//*


        register.classList.remove("formm");
        register.classList.add("activate");
        login.classList.remove("activate");
        login.classList.add("formm");
   
    
});*/


/*const loginbtn = document.querySelector("#login-button");
loginbtn.addEventListener("click", function () {
    const register = document.querySelector("#register");
    const login = document.querySelector("#login");

        register.classList.add("formm");
        register.classList.remove("activate");
        login.classList.add("activate");
        login.classList.remove("formm");
   
    
});*/


