const url = "https://localhost:5001/api/video/";

const button = document.querySelector("#run-button");
button.addEventListener("click", () => {
    getAllVideos()
        .then(Videos => {
            console.log(Videos);
        })
});

function getAllVideos() {
    return fetch(url).then(resp => resp.json());
}
