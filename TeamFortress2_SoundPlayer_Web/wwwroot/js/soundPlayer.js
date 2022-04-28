//Basic audio player
var isPlaying = false;
var audio = new Audio();

//These two events are switching the bool, to prevent voice spam
audio.onplaying = () => {
    isPlaying = true;
}
audio.onended = () => {
    isPlaying = false;
}

//The function that plays the audio
function Play(path) {
    if (!isPlaying) {
        audio.src = path;
        audio.play();
    }

}