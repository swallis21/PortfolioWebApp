function load_song(url) {
    let audio_controls = $("#audio-controls");
    audio_controls.children().remove();
    let new_song = $(document.createElement("audio"));
    new_song.attr("controls", "controls").attr("preload", "auto").attr("src", url).attr("type", "audio/mp3").attr("autoplay", "autoplay").on("ended", load_next_song);
    new_song[0].volume = 0.5;
    new_song.appendTo(audio_controls);
}

function load_next_song() {
    $.ajax({
        url: "/api/Music/NextSong"
    }).done(function (song) {
        load_song(song.url);
    }).fail(function () {
        console.error("Failed to load the next song :(");
    })
}
function load_random_song() {
    $.ajax({
        url: "/api/Music/RandomSong"
    }).done(function (song) {
        load_song(song.url);
    }).fail(function () {
        console.error("Failed to load a random song :(");
    })
    $(document).off("click");
}

$(document).on("click", load_random_song);