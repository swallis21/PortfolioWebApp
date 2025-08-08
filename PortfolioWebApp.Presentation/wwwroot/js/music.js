function load_song(url) {
    let audio_controls = $("#audio-controls");
    audio_controls.children("audio").remove();
    let new_song = $(document.createElement("audio"));
    new_song.attr("preload", "auto").attr("src", url).attr("type", "audio/mp3").on("ended", load_next_song);
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

function play_pause_music() {
    let player = $(this).parent();
    let audio_element = player.siblings("audio")[0];
    if (player.is(".paused")) {
        audio_element.play();
        player.removeClass("paused leashed");
        $(this).children("i").removeClass("fa-play").addClass("fa-pause");
    } else {
        audio_element.pause();
        player.addClass("paused");
        $(this).children("i").removeClass("fa-pause").addClass("fa-play");
    }
}

function setup_music() {
    $("#music-play a").on("click", play_pause_music);
    load_random_song();
}

$(document).ready(setup_music);