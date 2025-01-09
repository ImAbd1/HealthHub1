window.addEventListener("scroll", function () {
    var positionY = window.scrollY;
    mybutton = document.getElementById("myBtn");
    if (positionY > 20) {
      mybutton.style.display = "block";
    } else {
      mybutton.style.display = "none";
    }
  });
  
  function topFunction() {
    window.scrollTo({
      top: 0,
      behavior: "smooth",
    });
  }
  
  function menuExt() {
    document.getElementById("mySidenav").style.width = "200px";
  }
  
  function menuCls() {
    document.getElementById("mySidenav").style.width = "0px";
  }