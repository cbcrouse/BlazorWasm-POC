export function toggleSidebar() {
    let sidebar = document.querySelector(".sidebar");
    let homeContent = document.querySelector(".home_content");

    sidebar.classList.toggle("active");
    homeContent.classList.toggle("active");
}