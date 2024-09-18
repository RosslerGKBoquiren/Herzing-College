
const show_btn = document.getElementById('show_btn');
const grey_background = document.getElementById('grey_background');
const hidden_info = document.getElementById('hidden_info');
const close_btn = document.getElementById('close_btn');

function toggle_Hidden_info() {
	if(hidden_info.style.display === "block") {
		hidden_info.style.display = "none";
		grey_background.style.display = "none"
	} else {
		hidden_info.style.display = "block";
		grey_background.style.display = "block";
	}
}

show_btn.addEventListener('click', toggle_Hidden_info);
close_btn.addEventListener('click', toggle_Hidden_info);
