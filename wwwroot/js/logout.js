document.addEventListener("DOMContentLoaded", function () {
    const logoutBtn = document.querySelector(".logout");
  
    document.getElementById("hover").addEventListener("click", function (event) {
      event.preventDefault();
      if (logoutBtn.style.display === "flex") {
        logoutBtn.style.display = "none";
      } else {
        logoutBtn.style.display = "flex";
      }
    });
  });
  
