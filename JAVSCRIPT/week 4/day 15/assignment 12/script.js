
window.addEventListener('DOMContentLoaded', function() {
    let mainDiv = document.createElement("div");
    mainDiv.id = 'mainDiv';

    let text1 = document.createTextNode('The ');

    let boldFont = document.createElement('b');
    boldFont.textContent = 'World Wide Web Consortium';

    let text2 = document.createTextNode(', abbreviated to ');

    let strongFont = document.createElement('strong');
    strongFont.textContent = 'W3C';

    let text3 = document.createTextNode(', is a ');

    let link1 = document.createElement('a');
    link1.href = 'http://en.wikipedia.org/wiki/Standards_organization';
    link1.target = '_blank';
    link1.title = 'Standards organization';
    link1.textContent = 'Standards Organization.';

    let text4 = document.createTextNode(' A ');

    let italicFont = document.createElement('i');
    italicFont.textContent = 'non-profit';

    let text5 = document.createTextNode(' responsible for promoting the compatibility of the technologies ');

    let link2 = document.createElement('a');
    link2.href = 'http://en.wikipedia.org/wiki/World_Wide_Web';
    link2.target = '_blank';
    link2.title = 'World Wide Web';
    link2.textContent = 'World Wide Web';

    let text6 = document.createTextNode('.');

    let paragraph = document.createElement('p');
    paragraph.style.textAlign = 'right';
    paragraph.textContent = 'Your Name Here';


    mainDiv.appendChild(text1);
    mainDiv.appendChild(boldFont);
    mainDiv.appendChild(text2);
    mainDiv.appendChild(strongFont);
    mainDiv.appendChild(text3);
    mainDiv.appendChild(link1);
    mainDiv.appendChild(text4);
    mainDiv.appendChild(italicFont);
    mainDiv.appendChild(text5);
    mainDiv.appendChild(link2);
    mainDiv.appendChild(text6);
    mainDiv.appendChild(paragraph);


    document.body.appendChild(mainDiv);
});
