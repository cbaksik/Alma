// STACKMAP.COM CATALOGUE INTEGRATION
// NO JQUERY DEPENDENCY VERSION: 2017
// FOR: https://hollis.harvard.edu/primo-explore/

/* jshint scripturl:true */
/* jshint loopfunc:true */
var StackMap_dictionary = function () {
    var letters = {
        // lower case
        'à': 'a',
        'á': 'a',
        'â': 'a',
        'ä': 'a',

        'é': 'e',
        'è': 'e',
        'ê': 'e',
        'ë': 'e',

        'ì': 'i',
        'í': 'i',
        'î': 'i',
        'ï': 'i',
        'ĭ ': 'i',

        'ò': 'o',
        'ó': 'o',
        'ô': 'o',
        'ö': 'o',
        'œ': 'o',

        'ú': 'u',
        'ù': 'u',
        'û': 'u',
        'ü': 'u',
        'ų': 'u',

        'ÿ': 'y',
        'ç': 'c',
        'ñ': 'n',
        'n̈': 'n',
        'ß': 's',
        'ğ': 'g',
        'ş': 's',

        // uppercase
        'Á': 'A',
        'À': 'A',
        'Â': 'A',
        'Ä': 'A',

        'È': 'E',
        'É': 'E',
        'Ê': 'E',
        'Ë': 'E',

        'Î': 'I',
        'Ï': 'I',
        'Í': 'I',
        'İ': 'I',
        'Ĭ': 'I',

        'Ó': 'O',
        'Ò': 'O',
        'Ô': 'O',
        'Ö': 'O',
        'Œ': 'O',

        'Ù': 'U',
        'Ú': 'U',
        'Û': 'U',
        'Ü': 'U',
        'Ų': 'U',

        'Ÿ': 'Y',
        'Ç': 'C',
        'Ñ': 'N',
        'N̈': 'N',
        'Ğ': 'G',
        'Ş': 'S',
        'Ť': 'T'
    };

    function normalize(word) {
        return word.split('').map(function (char) {
            if (letters[char]) return letters[char];
            if (char.charCodeAt(0) > 122) return '';
            else return char;
        }).join('');
    }

    function clean(word) {
        return !word.split('').some(function (char) {
            return letters[char] || char.charCodeAt(0) > 122;
        });
    }

    return {
        normalize: normalize,
        clean: clean
    };
};

var StackMap = StackMap || {
    
    domain: 'https://harvard.stackmap.com', // TODO
    popupCounter: 0,
    delayImgLoad: true, // TODO
    libraries: {
        'Widener Library': 'Widener Library'
    },
    mobile: false,
    showBookTitle: true,
    dictionary: StackMap_dictionary(),
    setup: function () {
        StackMap.boxHeight = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
        if (/Android|webOS|iPhone|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
            StackMap.mobile = Math.max(document.documentElement.clientHeight, window.innerHeight || 0);
        }

        var d = document.documentElement;
        d.addEventListener('click', function (e) {
            var t = StackMap.utils.getEventTarget(e);
            $popup = e.srcElement ?
                e.srcElement.closest('.SMpopup') :
                e.target.closest('.SMpopup');

            if (StackMap.utils.hasClass(t, 'SMclose')) {
                e.preventDefault();
                e.stopPropagation();
                StackMap.hideAllPopups($popup);
            } else if (StackMap.utils.hasClass(t, 'SMprinter-friendly')) {
                e.preventDefault();
                e.stopPropagation();

                var cn = $popup.getAttribute('data-callno');
                var loc = $popup.getAttribute('data-location');
                var lib = $popup.getAttribute('data-library');
                var title = $popup.getAttribute('data-title');
                StackMap.openPrinterFriendly(cn, loc, lib, title);
            }
        });
        d.addEventListener('keydown', function (e) {
            var openModal = document.querySelector('.SMpopup-show');
            var buttonFocused = e.target.classList.contains('SMsearchbtn');
            var mz = StackMap.mapZoomer;

            if (buttonFocused && (e.key === 'Enter' || e.key === ' ')) {
                e.preventDefault();
                e.stopImmediatePropagation();
                e.stopPropagation();
                e.target.click();
            }
            if (openModal && mz) {
                var map = openModal.querySelector('.SMmap');
                var mapPos = {
                    left: parseInt(map.style.left),
                    top: parseInt(map.style.top),
                };
                switch (e.key) {
                    case 'Escape':
                        StackMap.hideAllPopups(openModal);
                        break;
                    case 'ArrowDown':
                        e.preventDefault();
                        mz.moveMap(mapPos.left, mapPos.top + 10);
                        break;
                    case 'ArrowUp':
                        e.preventDefault();
                        mz.moveMap(mapPos.left, mapPos.top - 10);
                        break;
                    case 'ArrowRight':
                        e.preventDefault();
                        mz.moveMap(mapPos.left + 10, mapPos.top);
                        break;
                    case 'ArrowLeft':
                        e.preventDefault();
                        mz.moveMap(mapPos.left - 10, mapPos.top);
                        break;

                    default:
                        break;
                }
            }
        });
    },
    scrapeDom: function () {
        var entries = [];
        var request = {
            holding: [],
            alt: true,
        };

        var $rows = document.querySelectorAll('.availability-status');
        for (var j = 0; j < $rows.length; j++) {
            var $row = $rows[j];
            if ($row.children.length === 0) {
                $row = $row.parentNode;
            }
            if (StackMap.utils.hasClass($row, 'sm-checked')) continue;
            var $container = $row.closest('.result-item-text')
            if (!$container) {
                continue;
            }

            var libraryNode = $row.querySelector('.best-location-library-code');
            var locationNode = $row.querySelector('.best-location-sub-location');
            var callnoNode = $row.querySelector('.best-location-delivery');
            var titleNode = $container.querySelector('.item-title');

            var data = {
                library: StackMap.utils.text(libraryNode),
                location: StackMap.utils.text(locationNode),
                callno: StackMap.utils.text(callnoNode),
                title: StackMap.utils.text(titleNode),
                status: StackMap.utils.text($row),
            };

            var library = StackMap.utils.translateLibrary(data);
            var location = StackMap.utils.translateLocation(data);
            var callno = StackMap.utils.translateCallno(data);
            var title = StackMap.utils.translateTitle(data);

            if (StackMap.utils.exitEarly(data)) continue;
            StackMap.utils.addClass($row, 'sm-checked');
            $container.setAttribute('data-title', title)
            var holdingString = library + '$$' + location + '$$' + callno;

            request.holding.push(holdingString);
            entries.push($container);
        }

        // var locationItems = document.querySelectorAll('.tab-content-header')
        // for (let i = 0; i < locationItems.length; i++) {
        //     var $row = locationItems[i];
        //     if (StackMap.utils.hasClass($row, 'sm-checked')) continue;
        //     if (!$row) continue;

        //     var libraryNode = $row.querySelector('.md-title');
        //     var statusNode = $row.querySelector('.availability-status');
        //     var spans = $row.querySelectorAll('span');
        //     var locationNode = spans[2];
        //     var callnoNode = spans[4];
        //     var data = {
        //         library: StackMap.utils.text(libraryNode).trim(),
        //         location: StackMap.utils.text(locationNode).trim(),
        //         callno: StackMap.utils.text(callnoNode).trim(),
        //         title: StackMap.utils.text(titleNode).trim(),
        //         status: StackMap.utils.text(statusNode).trim(),
        //     };
        //     var library = StackMap.utils.translateLibrary(data);
        //     var location = StackMap.utils.translateLocation(data)
        //     var callno = StackMap.utils.translateCallno(data);

        //     if (StackMap.utils.exitEarly(data)) continue;
        //     StackMap.utils.addClass($row, 'sm-checked');
        //     var holdingString = library + '$$' + location + '$$' + callno;

        //     var target = $row.querySelector('div.layout-row:not(.layout-align-start-start):not(.layout-align-end-center)')
        //     if (StackMap.showBookTitle) {
        //         var t = o.querySelectorAll('prm-icon-after');
        //         if (t === undefined || t[1] === undefined) {
        //             return;
        //         }
        //         var domTarget = target;

        //         var title = StackMap.utils.text(titleNode);
        //         if (title.indexOf("; ") === 0) {
        //             title = title.slice(2);
        //         }
        //         domTarget.setAttribute('data-title', title);
        //     }

        //     request.holding.push(holdingString);
        //     entries.push(target);
        // }

        // // var detailList = document.querySelectorAll('.holdingsList tr')
        // var locationsList = document.querySelectorAll('prm-locations .separate-list-items .md-list-item-text')
        // for (let i = 0; i < locationsList.length; i++) {
        //     var container = locationsList[i];
        //     if (StackMap.utils.hasClass(container, 'sm-checked')) continue;
        //     var row = locationsList[i].querySelector('div');
        //     var target = locationsList[i].querySelector('div.list-item-actions');
        //     var spans = row.querySelectorAll('p span');


        //     var libraryNode = row.querySelector('h3');
        //     var locationNode = spans[2];
        //     var callnoNode = spans[4];
        //     var statusNode = spans[0];

        //     var data = {
        //         library: StackMap.utils.text(libraryNode).trim(),
        //         location: StackMap.utils.text(locationNode).trim(),
        //         callno: StackMap.utils.text(callnoNode).trim(),
        //         title: StackMap.utils.text(titleNode).trim(),
        //         status: StackMap.utils.text(statusNode).trim(),
        //     };
        //     var library = StackMap.utils.translateLibrary(data);
        //     var location = StackMap.utils.translateLocation(data)
        //     var callno = StackMap.utils.translateCallno(data);

        //     if (StackMap.utils.exitEarly(data)) continue;
        //     StackMap.utils.addClass(container, 'sm-checked');
        //     var holdingString = library + '$$' + location + '$$' + callno;

        //     if (StackMap.showBookTitle) {
        //         var t = o.querySelectorAll('prm-icon-after');
        //         if (t === undefined || t[1] === undefined) {
        //             return;
        //         }
        //         var domTarget = target;

        //         var title = StackMap.utils.text(titleNode);
        //         if (title.indexOf("; ") === 0) {
        //             title = title.slice(2);
        //         }
        //         domTarget.setAttribute('data-title', title);
        //     }

        //     request.holding.push(holdingString);
        //     entries.push(target);
        // }

        if (request.holding.length === 0) { return; }
        StackMap.getJson(request, entries, 'jsonp');
    },
    partitionQueriesAndSend: function (payload, callback) {
        if (!Object.keys(payload).length) return;
        // Helper method for StackMap.getJson if querying multiple instances
        var cb = callback || StackMap.getJson
        for (var url in payload) {
            var entries = payload[url].entries
            var request = payload[url].request
            StackMap.getJson(request, entries, 'jsonp', url)
        }
    },
    getAsUriParameters: function (data) {
        return Object.keys(data).map(function (k) {
            if (Array.isArray(data[k])) {
                var keyE = encodeURIComponent(k + '[]');
                return data[k].map(function (subData) {
                    return keyE + '=' + encodeURIComponent(subData);
                }).join('&');
            } else {
                return encodeURIComponent(k) + '=' + encodeURIComponent(data[k]);
            }
        }).join('&');
    },
    jsonpWrapper: function (real_callback, request, entries) {
        var callback_name = 'jsonp_callback_' + Math.floor(Math.random() * 100000);
        window[callback_name] = function (response) {
            real_callback(response, request, entries);
            delete window[callback_name];
        };
        return callback_name;
    },
    loadJSONP: function (url, callback, arg) {
        var ref = window.document.getElementsByTagName('script')[0];
        var script = window.document.createElement('script');
        script.src = url + (url.indexOf('?') + 1 ? '&' : '?') + 'callback=' + callback;
        ref.parentNode.insertBefore(script, ref);
        script.onload = function () {
            this.remove();
        };
    },
    getJson: function (request, entries, type, optionaldomain) {
        if (type === 'jsonp') {
            var url = StackMap.domain + "/json/?callback=?";
            if (optionaldomain) url = optionaldomain + "/json/?callback=?";
            url = url + "&" + StackMap.getAsUriParameters(request);
            // callback wrapper to pass in extra args for jsonp
            var jsonp = StackMap.jsonpWrapper(StackMap.buildMapAndButtons, request, entries);
            StackMap.loadJSONP(url, jsonp);
        }
    },
    logClick: function (data) {
        var logURL = StackMap.domain + "/logmapit/?callback=?";
        logURL = logURL + "&" + StackMap.getAsUriParameters(data);

        function success() { }
        StackMap.loadJSONP(logURL, success);
    },
    buildMapAndButtons: function (data, request, entries) {
        for (var i = 0; i < entries.length; i++) {
            var result = data.results[i];
            if (result.maps.length !== 0) {
                map = result.maps[0];
                // POPUP
                var popup = document.createElement('div');
                popup.tabIndex = 0;
                StackMap.utils.addClass(popup, 'SMpopup');
                popup.id = "SM" + StackMap.popupCounter;
                popup.dataset.callno = result.callno;
                popup.dataset.location = result.location;
                popup.dataset.library = result.library;
                var clientLocationDisplay = StackMap.utils.createClientLocationDisplay(result.location);
                // HEADER
                var header = document.createElement('div');
                StackMap.utils.addClass(header, 'SMheader');

                var headerTopText = document.createElement('h1');
                headerTopText.textContent = 'HOLLIS StackMap';
                StackMap.utils.addClass(headerTopText, 'SMheader-top');

                var headerTitle = document.createElement('h2');
                var headerTitleTxt;
                if (entries[i].dataset.title) {
                    headerTitleTxt = entries[i].getAttribute('data-title');
                    headerTitleTxt = document.createTextNode(headerTitleTxt);
                } else {
                    headerTitleTxt = document.createTextNode(map.library + ', ' + map.floorname);
                }
                headerTitle.appendChild(headerTitleTxt);

                header.appendChild(headerTopText);
                popup.appendChild(header);
                // HEADER BTNS
                var closeBtn = document.createElement('a');
                closeBtn.href = "#";
                closeBtn.alt = "Close";
                closeBtn.ariaRole = "button";
                var closeIcon = document.createElement('i');
                StackMap.utils.addClass(closeBtn, "SMclose");
                StackMap.utils.addClass(closeIcon, ["fa", "fa-times", "fa-1x", "SMclose"]);
                var printBtn = document.createElement('a');
                printBtn.href = "#";
                printBtn.alt = "Printer Friendly";
                printBtn.ariaRole = "button";
                var printIcon = document.createElement('i');
                StackMap.utils.addClass(printBtn, "SMprinter-friendly");
                StackMap.utils.addClass(printIcon, ["fa", "fa-print", "fa-1x", "SMprinter-friendly"]);
                closeBtn.appendChild(closeIcon);
                printBtn.appendChild(printIcon);
                var reportAProblem = document.createElement('a');
                reportAProblem.textContent = 'Report A Problem';
                reportAProblem.setAttribute('href', 'http://nrs.harvard.edu/urn-3:HUL.ois:hollis-v2-feedback');
                reportAProblem.onclick = function (e) { // CC
                    e.preventDefault();
                    if (window.open) window.open(this.href);
                }
                // HEADER BTNS CONTAINER
                var headerBtns = document.createElement('div');
                headerBtns.appendChild(reportAProblem);
                headerBtns.appendChild(printBtn);
                headerBtns.appendChild(closeBtn);
                StackMap.utils.addClass(headerBtns, "SMheaderbtns");
                popup.appendChild(headerBtns);
                // SUB HEADER CONTENT

                var subHeaderContainer = document.createElement('div');
                subHeaderContainer.classList.add('SMsubheader');
                subHeaderContainer.appendChild(headerTitle);
                var subHeaderData = document.createElement('p');
                subHeaderData.textContent = result.library + ', ' + clientLocationDisplay + ', ' + result.callno;
                subHeaderContainer.appendChild(subHeaderData);
                var shareableLink = document.createElement('a');
                shareableLink.href = StackMap.domain + '/' +
                    'view/?callno=' + result.callno +
                    '&location=' + result.location.replace('&amp;', '%26') +
                    '&library=' + result.library;
                shareableLink.onclick = function (e) { // CC
                    e.preventDefault();
                    if (window.open) window.open(this.href);
                };
                shareableLink.textContent = 'Shareable Link';
                subHeaderContainer.appendChild(shareableLink);
                popup.appendChild(subHeaderContainer);
                // MAP IMG
                var mapImg = document.createElement('img');
                StackMap.utils.addClass(mapImg, ['SMmap']);

                var maptext = "Location of item with callnumber " + result.callno + " is " + result.library + ', ' + map.floorname;
                mapImg.setAttribute('alt', maptext);
                mapImg.setAttribute('draggable', 'true');

                // temp because I can't access their css file which they are hosting.
                mapImg.style.border = 'none';

                if (StackMap.delayImgLoad) {
                    mapImg.setAttribute('othersrc', map.mapurl + '&marker=1');
                } else {
                    mapImg.setAttribute('src', map.mapurl + '&marker=1');
                }

                // alternative way to pass original width and height to our zoomer
                mapImg.setAttribute('data-original-width', map.width)
                mapImg.setAttribute('data-original-height', map.height)

                var mapContainer = document.createElement('div');
                StackMap.utils.addClass(mapContainer, ['SMmap-container']);
                // Zoom btns
                var zoomBtns = document.createElement('ul');
                StackMap.utils.addClass(zoomBtns, 'SMmap-buttons');
                var zoominLi = document.createElement('li');
                var zoomoutLi = document.createElement('li');
                var zoomfitLi = document.createElement('li');
                var zoomin = document.createElement('a');
                var zoomout = document.createElement('a');
                var zoomfit = document.createElement('a');
                zoomin.tabIndex = 0;
                zoomout.tabIndex = 0;
                zoomfit.tabIndex = 0;
                StackMap.utils.addClass(zoomin, 'zoom-in');
                StackMap.utils.addClass(zoomout, 'zoom-out');
                StackMap.utils.addClass(zoomfit, 'zoom-fit');
                var zoominIcon = document.createElement('i');
                var zoomoutIcon = document.createElement('i');
                var zoomfitIcon = document.createElement('i');
                StackMap.utils.addClass(zoominIcon, ["fa", "fa-plus-circle", "SMicon", "fa-1x"]);
                StackMap.utils.addClass(zoomoutIcon, ["fa", "fa-minus-circle", "SMicon", "fa-1x"]);
                StackMap.utils.addClass(zoomfitIcon, ["fa", "fa-arrows", "SMicon", "fa-1x"]);
                var zoominTxtNode = document.createElement('span');
                var zoomoutTxtNode = document.createElement('span');
                var zoomfitTxtNode = document.createElement('span');
                var zoominTxt = document.createTextNode('zoom in');
                var zoomoutTxt = document.createTextNode('zoom out');
                var zoomfitTxt = document.createTextNode('entire map');
                zoominTxtNode.appendChild(zoominTxt);
                zoomoutTxtNode.appendChild(zoomoutTxt);
                zoomfitTxtNode.appendChild(zoomfitTxt);
                zoomin.appendChild(zoominIcon);
                zoomout.appendChild(zoomoutIcon);
                zoomfit.appendChild(zoomfitIcon);
                zoomin.appendChild(zoominTxtNode);
                zoomout.appendChild(zoomoutTxtNode);
                zoomfit.appendChild(zoomfitTxtNode);
                zoominLi.appendChild(zoomin);
                zoomoutLi.appendChild(zoomout);
                zoomfitLi.appendChild(zoomfit);
                zoomBtns.appendChild(zoominLi);
                zoomBtns.appendChild(zoomoutLi);
                zoomBtns.appendChild(zoomfitLi);

                var mapWindow = document.createElement('div');

                // Set Map Window dimensions
                mapWindow.style.height = map.height / 2 + 'px';
                mapWindow.tabIndex = 0;
                StackMap.utils.addClass(mapWindow, 'SMmap-window');
                mapWindow.appendChild(mapImg);


                /* Overlay (Deprecated)
                var mapOverlay = document.createElement('div');
                StackMap.utils.addClass(mapOverlay, 'SMmap-overlay');
                mapWindow.appendChild(mapOverlay);

                Overlay adding tooltip
                var r = map.ranges[0]
                var tooltiptarget = document.createElement("div");
                    StackMap.utils.addClass(tooltiptarget, ["SMpin-target", "loc-x", "loc-y", "size-x", "size-y"]);
                    tooltiptarget.setAttribute("width", mapWindow.style.height)
                    tooltiptarget.setAttribute("height", mapWindow.style.height)
                    tooltiptarget.dataset.x = r.x
                    tooltiptarget.dataset.y = r.y
                    mapOverlay.appendChild(tooltiptarget);
                var tooltip = document.createElement("div");
                    tooltip.id = "SMtooltip";
                    var p = document.createElement("p");
                    var tooltiptxt = document.createTextNode('tooltipping!!');
                    p.appendChild(tooltiptxt);
                    tooltip.appendChild(p);
                    tooltiptarget.appendChild(tooltip);
                */

                mapContainer.appendChild(zoomBtns);
                mapContainer.appendChild(mapWindow);

                // Side bar details
                /* client requested removal - content moved to header
                var sidebar = document.createElement('div');
                StackMap.utils.addClass(sidebar, 'SMmore-info');
                var sidebarContents = document.createElement('ul');
                var br = document.createElement('br')

                var line1 = document.createElement('li');
                var p1 = document.createElement('p');
                var strong1 = document.createElement('strong');
                var strongtxt = document.createTextNode('Directions:');
                strong1.appendChild(strongtxt);
                p1.appendChild(strong1);
                line1.appendChild(p1);
                var line2 = document.createElement('li');
                var p2 = document.createElement('p');

                StackMap.utils.addClass(p2, 'SMemph');
                var p2Txt = document.createTextNode(map.directions);
                var p2br = document.createElement('br')
                p2.appendChild(p2Txt);
                line2.appendChild(p2);
                line2.appendChild(p2br);

                var line3 = document.createElement('li');
                var p3 = document.createElement('p');
                StackMap.utils.addClass(p3, "SMdirectionstxt");
                var p3Txt = document.createTextNode("This pin indicates your item\'s location on the map");
                var p3Icon = document.createElement('i');
                p3Icon.setAttribute('aria-hidden', 'true');
                StackMap.utils.addClass(p3Icon, ["fa", "fa-map-marker", "fa-1x", "SMdirections"]);
                p3.appendChild(p3Icon);
                p3.appendChild(p3Txt);
                line3.appendChild(p3);
                var line4 = document.createElement('li');
                var p4 = document.createElement('p');
                var p4Txt = document.createTextNode("Go to the shelving row labeled:");
                p4.appendChild(p4Txt);
                line4.appendChild(p4);

                var line5 = document.createElement('li');
                var p5 = document.createElement('p');
                var p5br = document.createElement('br')
                StackMap.utils.addClass(p5, 'SMemph');
                var p5Txt = document.createTextNode(map.ranges[0].rangename);
                p5.appendChild(p5Txt);
                line5.appendChild(p5);
                line5.appendChild(p5br);

                var line6 = document.createElement('li');
                var p6 = document.createElement('p');
                var p6Txt = document.createTextNode("Look for the item with this call number: ");
                p6.appendChild(p6Txt);
                line6.appendChild(p6);

                var line7 = document.createElement('li');
                var p7 = document.createElement('p');
                StackMap.utils.addClass(p7, 'SMemph');
                var p7Txt = document.createTextNode(result.callno);
                p7.appendChild(p7Txt);
                line7.appendChild(p7);

                var liList = [line3, line1, line2, line4, line5, line6, line7]; // default
                if (map.ranges[0].rangename === 'Range') {
                    liList = [line3, line1, line2, br, line6, line7];
                }
                /* client requested removal - content moved to header
                var sidebar = document.createElement('div');
                StackMap.utils.addClass(sidebar, 'SMmore-info');
                var sidebarContents = document.createElement('ul');
                var br = document.createElement('br')

                var line1 = document.createElement('li');
                var p1 = document.createElement('p');
                var strong1 = document.createElement('strong');
                var strongtxt = document.createTextNode('Directions:');
                strong1.appendChild(strongtxt);
                p1.appendChild(strong1);
                line1.appendChild(p1);
                var line2 = document.createElement('li');
                var p2 = document.createElement('p');

                StackMap.utils.addClass(p2, 'SMemph');
                var p2Txt = document.createTextNode(map.directions);
                var p2br = document.createElement('br')
                p2.appendChild(p2Txt);
                line2.appendChild(p2);
                line2.appendChild(p2br);

                var line3 = document.createElement('li');
                var p3 = document.createElement('p');
                StackMap.utils.addClass(p3, "SMdirectionstxt");
                var p3Txt = document.createTextNode("This pin indicates your item\'s location on the map");
                var p3Icon = document.createElement('i');
                p3Icon.setAttribute('aria-hidden', 'true');
                StackMap.utils.addClass(p3Icon, ["fa", "fa-map-marker", "fa-1x", "SMdirections"]);
                p3.appendChild(p3Icon);
                p3.appendChild(p3Txt);
                line3.appendChild(p3);
                var line4 = document.createElement('li');
                var p4 = document.createElement('p');
                var p4Txt = document.createTextNode("Go to the shelving row labeled:");
                p4.appendChild(p4Txt);
                line4.appendChild(p4);

                var line5 = document.createElement('li');
                var p5 = document.createElement('p');
                var p5br = document.createElement('br')
                StackMap.utils.addClass(p5, 'SMemph');
                var p5Txt = document.createTextNode(map.ranges[0].rangename);
                p5.appendChild(p5Txt);
                line5.appendChild(p5);
                line5.appendChild(p5br);

                var line6 = document.createElement('li');
                var p6 = document.createElement('p');
                var p6Txt = document.createTextNode("Look for the item with this call number: ");
                p6.appendChild(p6Txt);
                line6.appendChild(p6);

                var line7 = document.createElement('li');
                var p7 = document.createElement('p');
                StackMap.utils.addClass(p7, 'SMemph');
                var p7Txt = document.createTextNode(result.callno);
                p7.appendChild(p7Txt);
                line7.appendChild(p7);

                var liList = [line3, line1, line2, line4, line5, line6, line7]; // default
                if (map.ranges[0].rangename === 'Range') {
                    liList = [line3, line1, line2, br, line6, line7];
                }

                for (var j = 0; j < liList.length; j++) {
                    var line = liList[j];
                    sidebarContents.appendChild(line);
                }

                sidebar.appendChild(sidebarContents);
                mapContainer.appendChild(sidebar);
                */
                // for (var j = 0; j < liList.length; j++) {
                //     var line = liList[j];
                //     sidebarContents.appendChild(line);
                // }

                // sidebar.appendChild(sidebarContents);
                // mapContainer.appendChild(sidebar);

                popup.appendChild(mapContainer);

                // Poweredby
                var poweredBy = document.createElement('p');
                StackMap.utils.addClass(poweredBy, 'SMpowered-by');
                var poweredByLink = document.createElement('a');
                StackMap.utils.addClass(poweredByLink, 'SMpowered-by-link');
                poweredByLink.setAttribute('href', "http://stackmap.com");
                var poweredByTxt = document.createTextNode('StackMap.com');
                var prefixTxt = document.createTextNode("Powered by");
                poweredByLink.appendChild(poweredByTxt);
                poweredBy.appendChild(prefixTxt);
                poweredBy.appendChild(poweredByLink);
                popup.appendChild(poweredBy);

                // sidebarContents.appendChild(line8);
                // sidebarContents.appendChild(line8);
                var body = document.getElementsByTagName('body')[0];

                // Outer container for flex box full screen block
                var outercontainer = document.createElement('div');
                StackMap.utils.addClass(outercontainer, 'SMblock-screen');
                outercontainer.appendChild(popup);
                body.appendChild(outercontainer);

                // Search btn
                var searchBtn = document.createElement('button');
                StackMap.utils.addClass(searchBtn, ['SMButton', 'SMsearchbtn']);
                searchBtn.setAttribute('type', 'button');
                searchBtn.dataset.id = StackMap.popupCounter;

                (function (id) {
                    searchBtn.addEventListener('click', function (e) {
                        if (!e) e = windows.event;
                        e.cancelBubble = true;
                        if (e.stopPropagation) e.stopPropagation();
                        StackMap.showPopup('SM' + id, e);
                    });
                })(StackMap.popupCounter);

                var generateCustomClientButtonText = function (result) {
                    var map = result.maps[0];
                    var customClientButtonTxt = {
                        library: {
                            'Widener Library': 'Widener',
                            'Lamont Library': 'Lamont',
                            'Harvard Law School Library': 'Law',
                        },
                    };
                    var t = customClientButtonTxt;
                    if (!map.ranges[0].rangename) return 'Map it: ' + t.library[result.library];
                    return 'Map it: ' + t.library[result.library] + ' ' + map.ranges[0].rangename;
                };

                // var searchTxt = document.createTextNode("Map it");
                var searchTxt = document.createTextNode(generateCustomClientButtonText(result));
                var searchIcon = document.createElement('i');
                StackMap.utils.addClass(searchIcon, ['fa', 'fa-map-marker', 'searchIcon']);

                searchBtn.appendChild(searchIcon);
                searchBtn.appendChild(searchTxt);

                if (!entries[i].querySelectorAll('.SMsearchbtn-container').length) {
                    var multiButtonContainer = document.createElement('p');
                    multiButtonContainer.classList.add('SMsearchbtn-container')
                    entries[i].appendChild(multiButtonContainer);
                } else {
                    multiButtonContainer = entries[i].querySelector('.SMsearchbtn-container')
                }

                searchBtn.style.zIndex = 1000;
                multiButtonContainer.appendChild(searchBtn);
                StackMap.popupCounter++;
            }
        }
    },
    openPrinterFriendly: function (callno, location, library, title) {
        var pfUrl = StackMap.domain + '/view/?callno=' + encodeURIComponent(callno) +
            '&amp;location=' + encodeURIComponent(location).replace('&amp;', '%26') +
            '&amp;library=' + encodeURIComponent(library) + '&amp;title=' +
            encodeURIComponent(title) + '&amp;v=pf';
        var dimensions = 'width=950,height=800,toolbar=no,directories=no,' +
            'scrollbars=1,location=no,menubar=no,status=no,left=0,top=0';
        window.open(pfUrl, 'stackmap', dimensions);
        return false;
    },
    showPopup: function (popupId, e) {
        var p = document.getElementById(popupId);
        var SMcontainer = p.closest('.SMblock-screen');
        var im = p.querySelector(".SMmap");
        if (!e) e = window.event;
        e.cancelBubble = true;
        if (e.stopPropagation) e.stopPropagation();

        if (StackMap.delayImgLoad) {
            im.setAttribute('src', im.getAttribute('othersrc'));
        }
        // log update analytics on server
        StackMap.logClick({
            callno: p.dataset.callno,
            library: p.dataset.library,
            location: p.dataset.location,
            action: 'mapit'
        });

        // SHOW POPUP
        // animation version
        StackMap.utils.addClass(p, "SMpopup-show");

        var zoomOptions = {
            container: SMcontainer,
            originalWidth: im.dataset.originalWidth,
            originalHeight: im.dataset.originalHeight,
        };

        StackMap.utils.addClass(SMcontainer, "SMoutercontainer-on");
        StackMap.utils.addClass(p, "SMpopup-show");
        SMcontainer.onmousedown = StackMap.utils.handleContainerClose;
        StackMap.mapZoomer = new StackMap.utils.StackMapZoomMap(zoomOptions);
        StackMap.mapZoomer.resetMap();

        p.focus();
    },
    // hideAllPopups: function (element) {
    hideAllPopups: function (event) {
        var popups = document.getElementsByClassName('SMoutercontainer-on');
        for (var i = 0; i < popups.length; i++) {
            var element = popups[i];
            StackMap.utils.removeClass(element, "SMoutercontainer-on");
        }
        return false;
    },
    // },
    utils: {
        translateTitle: function (data) {
            if (data.title.indexOf("; ") === 0) {
                return data.title.slice(2);
            }
            return data.title;
        },
        translateCallno: function (data) {
            var callno = data.callno.replace(/\(|\)/g, '').trim();
            return StackMap.dictionary.normalize(callno);
        },
        translateLocation: function (data) {
            if (data.location.indexOf('- ') === 0) {
                return data.location.slice(2);
            }
            cnsuffix = ' F';
            if (data.callno.slice(data.callno.length - cnsuffix.length, data.callno.length) === cnsuffix &&
                data.library === 'Widener Library' &&
                data.location === 'WID-LC') {
                return 'WID-LC F';
            }
            var cnsuffix2 = ' PF';
            if (data.callno.slice(data.callno.length - cnsuffix2.length, data.callno.length) === cnsuffix2 &&
                data.library === 'Widener Library' &&
                data.location === 'WID-LC') {
                return 'WID-LC PF';
            }
            var cnsuffix3 = ' HEBREW';
            if (data.callno.slice(data.callno.length - cnsuffix3.length, data.callno.length) === cnsuffix3 &&
                data.library === 'Widener Library' &&
                data.location === 'WID-LC') {
                return 'WID-LC HEBREW';
            }
            var cnsuffix4 = ' F';
            if (data.callno.slice(data.callno.length - cnsuffix4.length, data.callno.length) === cnsuffix4 &&
                data.library === 'Widener Library' &&
                (data.location === 'GEN' || data.location === 'Old Widener')) {
                return 'GEN F';
            }
            var cnsuffix5 = ' PF';
            if (data.callno.slice(data.callno.length - cnsuffix5.length, data.callno.length) === cnsuffix5 &&
                data.library === 'Widener Library' &&
                (data.location === 'GEN' || data.location === 'Old Widener')) {
                return 'GEN PF';
            }
            return data.location;
        },
        translateLibrary: function (data) {
            return data.library;
        },
        createClientLocationDisplay: function (location) {
            if (location === 'WID-LC PF') return 'WID-LC';
            if (location === 'WID-LC F') return 'WID-LC';
            if (location === 'WID-LC HEBREW') return 'WID-LC';
            if (location === 'GEN F') return 'Old Widener';
            if (location === 'GEN PF') return 'Old Widener';
            return location;
        },
        ancestorForSelector: function (node, selector) {
            while (node && !StackMap.utils.hasClass(node, selector)) {
                node = node.parentNode;
            }
            return node;
        },
        ancestorForDialogContainer: function (node) {
            while (node && !StackMap.utils.hasClass(node, 'md-dialog-container')) {
                node = node.parentNode;
            }
            return node;
        },
        exitEarly: function (data) {
            // default
            if (data.library === '' || data.library === undefined) return true;
            if (data.location === '' || data.location === undefined) return true;
            if (data.callno === '' || data.callno === undefined) return true;

            // custom
            if (data.location === 'Searching...Unavailable') {
                return true;
            }
            if (data.location === '' || data.callno === '') {
                return true;
            }
            if (data.location === 'On hold for someone' || data.location === 'Item has been checked out') {
                return true;
            }
            var firstChar = data.location.charCodeAt(0);
            if (!(firstChar >= 65 && firstChar <= 90) && !(firstChar >= 97 && firstChar <= 122)) {
                return true;
            }
            return false;
        },
        text: function (node) {
            if (!node) return '';

            if (node.textContent) {
                return node.textContent.trim();
            } else if (node.innerText) {
                return node.innerText.trim().replace('\n', ' ');
            } else {
                return '';
            }
        },
        hasClass: function (element, cls) {
            return (' ' + element.className + ' ').indexOf(' ' + cls + ' ') > -1;
        },
        removeClass: function (a, cls) {
            if (a.classList) {
                a.classList.remove(cls);
            } else {
                a.className.replace(cls, "");
            }

        },
        addClass: function (a, cls) {
            if (Array.isArray(cls)) {
                var l = !!a.classList;
                for (var i = 0; i < cls.length; i++) {
                    var c = cls[i];
                    if (l) {
                        a.classList.add(c);
                    } else {
                        a.className += c;
                    }
                }
            } else {
                if (a.classList) {
                    a.classList.add(cls);
                } else {
                    a.className += cls;
                }
            }
        },
        getEventTarget: function (e) {
            e = e || window.event;
            return e.target || e.srcElement;
        },
        getOffset: function (el) {
            var _x = 0;
            var _y = 0;
            while (el && !isNaN(el.offsetLeft) && !isNaN(el.offsetTop)) {
                _x += el.offsetLeft - el.scrollLeft;
                _y += el.offsetTop - el.scrollTop;
                el = el.offsetParent;
            }
            return {
                top: _y,
                left: _x
            };
        },
        round: function (number, precision) {
            var factor = Math.pow(10, precision);
            var tempNumber = number * factor;
            var roundedTempNumber = Math.round(tempNumber);
            return roundedTempNumber / factor;
        },
        handleContainerClose: function (e) {
            // click only on container
            if (e.currentTarget && e.currentTarget === e.target) {
                StackMap.hideAllPopups();
            }
            return;
        },
        StackMapZoomMap: function (o) {
            var m = this;
            var defaultzoom = 1;
            m.boxHeight = (o.boxWidth / defaultzoom) || 510;
            m.boxWidth = (o.boxWidth / defaultzoom) || 680;
            m.container = o.container || document.getElementById('SMmap-container');
            m.fitX = 0;
            m.fitY = 0;
            m.lockEdges = false;
            m.mapSelector = '.SMmap';
            m.originalWidth = o.originalWidth || 800;
            m.originalHeight = o.originalHeight || 600;
            m.windowSelector = '.SMmap-window';
            m.zoomFactor = 0.1; // factor to change image
            m.zoomFit = (StackMap.mobile) ? 0.3 : 0.25; //if -1; then zoom all the way ou;
            m.zoomFitBtn = '.zoom-fit';
            m.zoomInBtn = '.zoom-in';
            m.zoomMin = 0.1; // lower bound to scale image
            m.zoomMax = 2; // upper bound to scale image
            m.zoomOutBtn = '.zoom-out'; // selector for zoom button

            m.mapWindow = m.container.querySelector(m.windowSelector);
            m.map = m.mapWindow.querySelector(m.mapSelector);
            m.popupWindow = m.mapWindow.querySelector('.SMpopup');
            m.halfBoxHeight = m.boxHeight / defaultzoom;
            m.halfBoxWidth = m.boxWidth / defaultzoom;


            m.curZoomFactor = 1;
            m.zoomFactorElem = m.mapWindow.querySelector(m.zoomFactorSelector);

            if (m.zoomFit == -1) m.zoomFit = m.zoomMin;

            m.curSize = {
                x: 0,
                y: 0
            };

            m.mousePosition = {
                x: 0,
                y: 0
            };

            m.calculateCenterCoords = function (windowElem, mapElem) {
                var windowDimensions = windowElem.getBoundingClientRect();
                var mapDimensions = mapElem.getBoundingClientRect();

                var halfWindowH = Math.ceil(windowDimensions.height / 2);
                var halfWindowW = Math.ceil(windowDimensions.width / 2);
                var halfMapH = Math.ceil(mapDimensions.height / 2);
                var halfMapW = Math.ceil(mapDimensions.width / 2);

                var y = halfWindowH - halfMapH;
                var x = halfWindowW - halfMapW;

                return {
                    x: x,
                    y: y
                };
            }

            m.getMapSizeRatio = function () {
                return m.originalHeight / m.curSize.y
            }

            m.updateOverlaySize = function () {
                for (var i = 0; i < m.sizeXContents.length; i++) {
                    var w = m.sizeXContents[i];
                    w.setAttribute('width', m.curSize.x + 'px');
                }
                for (var j = 0; j < m.sizeYContents.length; j++) {
                    var h = m.sizeYContents[j];
                    h.setAttribute('height', m.curSize.y + 'px');
                }
                for (var k = 0; k < m.locXContents.length; k++) {
                    var x = m.locXContents[k]
                    var newX = parseInt(x.dataset.x) / m.getMapSizeRatio();
                    x.style.left = newX + 'px';
                }
                for (var l = 0; l < m.locYContents.length; l++) {
                    var y = m.locYContents[l];
                    var newY = parseInt(y.dataset.y) / m.getMapSizeRatio();
                    y.style.top = newY + 'px';
                }
            }

            function setMapWindowDimensions() {
                var w = m.mapWindow.getBoundingClientRect();
                m.boxHeight = w.height;
                m.boxWidth = w.width;
            }

            m.resetMapByHeight = function () {
                var newZoomFactor = (m.boxHeight / m.originalHeight);
                m.setZoomFactor(newZoomFactor, false)
                var newLeft = (m.boxWidth - m.curSize.x) / 2;
                m.moveMap(newLeft, 0)
            }

            m.resetMapByWidth = function () {
                var newZoomFactor = (m.boxWidth / m.originalWidth);
                m.setZoomFactor(newZoomFactor, false);
                var newTop = (m.boxHeight - m.curSize.y) / 2;
                m.moveMap(0, newTop);
            }

            m.resetMap = function (move) {
                // re-evaluates the window container for caching
                setMapWindowDimensions();
                var boxRatio = m.boxHeight / m.boxWidth;
                var mapRatio = m.originalHeight / m.originalWidth;
                (boxRatio < mapRatio) ? m.resetMapByHeight() : m.resetMapByWidth();
            }

            m.moveMap = function (x, y) {
                var newX = x,
                    newY = y;
                var padding = 20;
                var edge = {
                    left: 0,
                    right: 0,
                    top: 0,
                    bottom: 0,
                };

                if (m.lockEdges) {
                    edge.right = (-m.curSize.x + m.boxWidth);
                    edge.top = (-m.curSize.y + m.boxHeight);

                    newX = newX < edge.right ? edge.right : newX;
                    newY = newY < edge.top ? edge.top : newY;
                    newX = newX > 0 ? 0 : newX;
                    newY = newY > 0 ? 0 : newY;
                } else { // with bumpers
                    edge.top = (-m.curSize.y + padding);
                    edge.left = (-m.curSize.x + padding);
                    edge.right = (m.boxWidth - padding);
                    edge.bottom = (m.boxHeight - padding);

                    newX = newX < edge.left ? edge.left : newX;
                    newX = newX > edge.right ? edge.right : newX;
                    newY = newY < edge.top ? edge.top : newY;
                    newY = newY > edge.bottom ? edge.bottom : newY;
                }
                m.map.style.left = newX + 'px';
                m.map.style.top = newY + 'px';
            }

            m.setZoomFactor = function (newZoomFactor, shouldMove) {
                shouldMove = (shouldMove !== undefined) ? shouldMove : true;
                if (m.curZoomFactor == newZoomFactor) return;
                if (newZoomFactor < m.zoomMin) newZoomFactor = m.zoomMin;
                if (newZoomFactor > m.zoomMax) newZoomFactor = m.zoomMax;

                var zoomFactorDelta = m.curZoomFactor - newZoomFactor;
                var shift = { // image scale shift
                    x: (m.originalWidth * zoomFactorDelta) / 2,
                    y: (m.originalHeight * zoomFactorDelta) / 2
                };
                var shiftX = parseFloat(m.map.style.left) + shift.x;
                var shiftY = parseFloat(m.map.style.top) + shift.y;
                // update store
                m.curZoomFactor = newZoomFactor;
                m.curSize.x = m.originalWidth * newZoomFactor;
                m.curSize.y = m.originalHeight * newZoomFactor;
                // map
                m.map.style.width = m.curSize.x + 'px';
                m.map.style.height = m.curSize.y + 'px';

                if (shouldMove) m.moveMap(shiftX, shiftY);
            };

            // Drag
            m.drag = false;

            function startDrag(e) {
                e.preventDefault();
                if (!e) e = window.event;
                var targ = e.target ? e.target : e.srcElement;
                var eType = e.type.toLowerCase();
                if (targ.className !== 'SMmap') {
                    return;
                }
                // calculate event X, Y coordinates
                offsetX = e.clientX;
                offsetY = e.clientY;
                // assign default values for top and left properties
                if (!targ.style.left) {
                    targ.style.left = '0px';
                }
                if (!targ.style.top) {
                    targ.style.top = '0px';
                }
                // calculate integer values for top and left
                coordX = parseInt(targ.style.left);
                coordY = parseInt(targ.style.top);
                m.drag = true;
                m.map.addEventListener('mousemove', dragDiv);
            }

            function dragDiv(e) {
                e.preventDefault();
                if (!m.drag) return;
                if (!e) e = window.event;
                var targ = e.target ? e.target : e.srcElement;
                // move div element
                targ.style.left = coordX + e.clientX - offsetX + 'px';
                targ.style.top = coordY + e.clientY - offsetY + 'px';
                return false;
            }

            function stopDrag(e) {
                if (e.currentTarget === m.container) {
                    // ...
                }
                m.drag = false;
                m.map.removeEventListener('mousemove', dragDiv);
                m.map.removeEventListener('mousedown', startDrag);
            };

            var zoomOut = function (e) {
                e = e || window.event;
                if (e.type === 'keydown' && !(e.key === 'Enter' || e.key === ' ')) return;
                var step = e.type === 'wheel' ? 0.04 : m.zoomFactor;
                var newZoomFactor = m.curZoomFactor - step;
                zoomButtonGreyOut(newZoomFactor);
                m.setZoomFactor(newZoomFactor, true);
            };

            var zoomIn = function (e) {
                e = e || window.event;
                if (e.type === 'keydown' && !(e.key === 'Enter' || e.key === ' ')) return;
                var step = e.type === 'wheel' ? 0.04 : m.zoomFactor;
                var newZoomFactor = m.curZoomFactor + step;
                zoomButtonGreyOut(newZoomFactor)
                m.setZoomFactor(newZoomFactor, true);
            };

            var zoomFit = function (e) {
                if (e.type === 'keydown' && !(e.key === 'Enter' || e.key === ' ')) return;
                zoomButtonGreyOut('reset');
                m.resetMap(true);
            };

            m.map.addEventListener('mousedown', function (e) {
                startDrag(e, m.map, m.mapWindow);
                document.addEventListener('mouseup', stopDrag, false, {
                    'once': true
                });
            });

            m.map.addEventListener('touchstart', function (e) {
                startDrag(e, m.map, m.mapWindow);
                document.addEventListener('touchend', stopDrag, {
                    'once': true
                });
            });

            // Map buttons
            // m.container.addEventListener('mousedown', function (e) {
            //     if (e.target !== m.container) return;
            //     StackMap.hideAllPopups(m.container);
            // }, false);

            // m.container.addEventListener('touchstart', function (e) {
            //     if (e.target !== m.container) return;
            //     StackMap.hideAllPopups(m.container);
            // }, false);

            var closeBtn = m.container.querySelector('.SMclose');
            var printBtn = m.container.querySelector('.SMprinter-friendly');
            var zoomInBtn = m.container.querySelector('.zoom-in');
            var zoomOutBtn = m.container.querySelector('.zoom-out');
            var zoomFitBtn = m.container.querySelector('.zoom-fit');

            zoomOutBtn.onclick = zoomOut
            zoomOutBtn.onkeydown = zoomOut

            zoomInBtn.onclick = zoomIn
            zoomInBtn.onkeydown = zoomIn

            zoomFitBtn.onclick = zoomFit
            zoomFitBtn.onkeydown = zoomFit

            var mouseWheelHandler = function (event) {
                event.preventDefault();
                var e = window.event || e; // old IE support
                var delta = Math.sign(event.wheelDelta || -event.detail || e.deltaY);
                if (delta > 0) zoomIn(event);
                if (delta < 0) zoomOut(event);
                return false;

            };
            m.mapWindow.onscroll = mouseWheelHandler;
            m.mapWindow.onwheel = mouseWheelHandler;

            var zoomButtonGreyOut = function (newZoomFactor) {
                // hook for styling maxed out buttons
                var $zoomInCapped = StackMap.utils.hasClass(zoomInBtn, 'sm-capped')
                var $zoomOutCapped = StackMap.utils.hasClass(zoomOutBtn, 'sm-capped')
                if (newZoomFactor === 'reset') {
                    if ($zoomInCapped) {
                        zoomInBtn.classList.remove('sm-capped')
                    }
                    if ($zoomOutCapped) {
                        zoomOutBtn.classList.remove('sm-capped')
                    }
                    return;
                }
                if (newZoomFactor <= m.zoomMin && !$zoomOutCapped) {
                    zoomOutBtn.classList.add('sm-capped')
                }
                if (newZoomFactor > m.zoomMin && $zoomOutCapped) {
                    zoomOutBtn.classList.remove('sm-capped')
                }
                if (newZoomFactor >= m.zoomMax && !$zoomInCapped) {
                    zoomInBtn.classList.add('sm-capped')
                }
                if (newZoomFactor < m.zoomMax && $zoomInCapped) {
                    zoomInBtn.classList.remove('sm-capped')
                }
            };

            m.resetMap(true);
        },
    },
    init: function () {
        StackMap.setup();

        // V1: SIMPLE INTERVAL
        var interval = 3000;
        setInterval(function () {
            StackMap.scrapeDom();
        }, interval);

        /*
        // V2: clickable refresh
        d.addEventListener('click', function(e){
        var t = StackMap.utils.getEventTarget(e);

        // click events to retrigger dom scrapping over an interaval
        var titleLinkClicked = StackMap.utils.hasClass(t, 'displayDetailLink');
        var imgLinkClicked = StackMap.utils.hasClass(t, 'results_img_div');
        var interval = 2000;
        var counterTimes = 5;
        var btnconfirm = StackMap.utils.hasClass(t, 'button-confirm')
            if (btnconfirm){
                var counter = 0;
                var intervalId = setInterval(function(){
                    counter++;
                    StackMap.scrapeDom();
                    if (counter > counterTimes){
                        clearInterval(intervalId);
                    }
                }, interval);
             }
         });
         */

        /*
        V3: simple interval limited
        var counter = 0
        var intervalID = setInterval(function(){
            counter++;
            if (counter >= 3){
                clearInterval(intervalID)
            }
        }, 2000)
        */
    }
};
// Lookups for integrations if querying multiple libraries.
function SMSetLibrary(libraryName) {    
    console.log('locally hosted vendor file - libraryName function');
    if (!libraryName) return false;
    var libCode = {
        "Widener Library": "harvard",
        "Lamont Library": "harvard",
        "Harvard Law School Library": "harvard",
    };
    var config = {
        "harvard": {
            stackmapdomain: 'https://harvard.stackmap.com/',
            stackmaplibraries: {}
        },
    };
    var libLookup = libCode[libraryName];
    return config[libLookup];
}

SMcontentLoaded(window, StackMap.init);

/*!
 * contentloaded.js
 *
 * Author: Diego Perini (diego.perini at gmail.com)
 * Summary: cross-browser wrapper for DOMContentLoaded
 * Updated: 20101020
 * License: MIT
 * Version: 1.2
 *
 * URL:
 * http://javascript.nwbox.com/ContentLoaded/
 * http://javascript.nwbox.com/ContentLoaded/MIT-LICENSE
 *
 */

// @win window reference
// @fn function reference
function SMcontentLoaded(win, fn) {
    var done = false,
        top = true,

        doc = win.document,
        root = doc.documentElement,
        modern = doc.addEventListener,

        add = modern ? 'addEventListener' : 'attachEvent',
        rem = modern ? 'removeEventListener' : 'detachEvent',
        pre = modern ? '' : 'on',

        init = function (e) {
            if (e.type == 'readystatechange' && doc.readyState != 'complete') return;
            (e.type == 'load' ? win : doc)[rem](pre + e.type, init, false);
            if (!done && (done = true)) fn.call(win, e.type || e);
        },

        poll = function () {
            try {
                root.doScroll('left');
            } catch (e) {
                setTimeout(poll, 50);
                return;
            }
            init('poll');
        };

    if (doc.readyState == 'complete') fn.call(win, 'lazy');
    else {
        if (!modern && root.doScroll) {
            try {
                top = !win.frameElement;
            } catch (e) { }
            if (top) poll();
        }
        doc[add](pre + 'DOMContentLoaded', init, false);
        doc[add](pre + 'readystatechange', init, false);
        win[add](pre + 'load', init, false);
    }

}


// drag drop polyfill
var DragDropTouch;
(function (DragDropTouch_1) {
    'use strict';
    /**
     * Object used to hold the data that is being dragged during drag and drop operations.
     *
     * It may hold one or more data items of different types. For more information about
     * drag and drop operations and data transfer objects, see
     * <a href="https://developer.mozilla.org/en-US/docs/Web/API/DataTransfer">HTML Drag and Drop API</a>.
     *
     * This object is created automatically by the @see:DragDropTouch singleton and is
     * accessible through the @see:dataTransfer property of all drag events.
     */
    var DataTransfer = (function () {
        function DataTransfer() {
            this._dropEffect = 'move';
            this._effectAllowed = 'all';
            this._data = {};
        }
        Object.defineProperty(DataTransfer.prototype, "dropEffect", {
            /**
             * Gets or sets the type of drag-and-drop operation currently selected.
             * The value must be 'none',  'copy',  'link', or 'move'.
             */
            get: function () {
                return this._dropEffect;
            },
            set: function (value) {
                this._dropEffect = value;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(DataTransfer.prototype, "effectAllowed", {
            /**
             * Gets or sets the types of operations that are possible.
             * Must be one of 'none', 'copy', 'copyLink', 'copyMove', 'link',
             * 'linkMove', 'move', 'all' or 'uninitialized'.
             */
            get: function () {
                return this._effectAllowed;
            },
            set: function (value) {
                this._effectAllowed = value;
            },
            enumerable: true,
            configurable: true
        });
        Object.defineProperty(DataTransfer.prototype, "types", {
            /**
             * Gets an array of strings giving the formats that were set in the @see:dragstart event.
             */
            get: function () {
                return Object.keys(this._data);
            },
            enumerable: true,
            configurable: true
        });
        /**
         * Removes the data associated with a given type.
         *
         * The type argument is optional. If the type is empty or not specified, the data
         * associated with all types is removed. If data for the specified type does not exist,
         * or the data transfer contains no data, this method will have no effect.
         *
         * @param type Type of data to remove.
         */
        DataTransfer.prototype.clearData = function (type) {
            if (type !== null) {
                delete this._data[type];
            } else {
                this._data = null;
            }
        };
        /**
         * Retrieves the data for a given type, or an empty string if data for that type does
         * not exist or the data transfer contains no data.
         *
         * @param type Type of data to retrieve.
         */
        DataTransfer.prototype.getData = function (type) {
            return this._data[type] || '';
        };
        /**
         * Set the data for a given type.
         *
         * For a list of recommended drag types, please see
         * https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/Recommended_Drag_Types.
         *
         * @param type Type of data to add.
         * @param value Data to add.
         */
        DataTransfer.prototype.setData = function (type, value) {
            this._data[type] = value;
        };
        /**
         * Set the image to be used for dragging if a custom one is desired.
         *
         * @param img An image element to use as the drag feedback image.
         * @param offsetX The horizontal offset within the image.
         * @param offsetY The vertical offset within the image.
         */
        DataTransfer.prototype.setDragImage = function (img, offsetX, offsetY) {
            var ddt = DragDropTouch._instance;
            ddt._imgCustom = img;
            ddt._imgOffset = {
                x: offsetX,
                y: offsetY
            };
        };
        return DataTransfer;
    }());
    DragDropTouch_1.DataTransfer = DataTransfer;
    /**
     * Defines a class that adds support for touch-based HTML5 drag/drop operations.
     *
     * The @see:DragDropTouch class listens to touch events and raises the
     * appropriate HTML5 drag/drop events as if the events had been caused
     * by mouse actions.
     *
     * The purpose of this class is to enable using existing, standard HTML5
     * drag/drop code on mobile devices running IOS or Android.
     *
     * To use, include the DragDropTouch.js file on the page. The class will
     * automatically start monitoring touch events and will raise the HTML5
     * drag drop events (dragstart, dragenter, dragleave, drop, dragend) which
     * should be handled by the application.
     *
     * For details and examples on HTML drag and drop, see
     * https://developer.mozilla.org/en-US/docs/Web/Guide/HTML/Drag_operations.
     */
    var DragDropTouch = (function () {
        /**
         * Initializes the single instance of the @see:DragDropTouch class.
         */
        function DragDropTouch() {
            this._lastClick = 0;
            // enforce singleton pattern
            if (DragDropTouch._instance) {
                throw 'DragDropTouch instance already created.';
            }
            // detect passive event support
            // https://github.com/Modernizr/Modernizr/issues/1894
            var supportsPassive = false;
            document.addEventListener('test', null, {
                get passive() {
                    supportsPassive = true;
                    return true;
                }
            });
            // listen to touch events
            if ('ontouchstart' in document) {
                var opt = (supportsPassive ? {
                    passive: true,
                    capture: false
                } : false);
                var d = document,
                    ts = this._touchstart.bind(this),
                    tm = this._touchmove.bind(this),
                    te = this._touchend.bind(this);
                d.addEventListener('touchstart', ts, opt);
                d.addEventListener('touchmove', tm, opt);
                d.addEventListener('touchend', te);
                d.addEventListener('touchcancel', te);
            }
        }
        /**
         * Gets a reference to the @see:DragDropTouch singleton.
         */
        DragDropTouch.getInstance = function () {
            return DragDropTouch._instance;
        };
        // ** event handlers
        DragDropTouch.prototype._touchstart = function (e) {
            var _this = this;
            if (this._shouldHandle(e)) {
                // raise double-click and prevent zooming
                if (Date.now() - this._lastClick < DragDropTouch._DBLCLICK) {
                    if (this._dispatchEvent(e, 'dblclick', e.target)) {
                        e.preventDefault();
                        this._reset();
                        return;
                    }
                }
                // clear all variables
                this._reset();
                // get nearest draggable element
                var src = this._closestDraggable(e.target);
                if (src) {
                    // give caller a chance to handle the hover/move events
                    if (!this._dispatchEvent(e, 'mousemove', e.target) &&
                        !this._dispatchEvent(e, 'mousedown', e.target)) {
                        // get ready to start dragging
                        this._dragSource = src;
                        this._ptDown = this._getPoint(e);
                        this._lastTouch = e;
                        e.preventDefault();
                        // show context menu if the user hasn't started dragging after a while
                        setTimeout(function () {
                            if (_this._dragSource == src && _this._img === null) {
                                if (_this._dispatchEvent(e, 'contextmenu', src)) {
                                    _this._reset();
                                }
                            }
                        }, DragDropTouch._CTXMENU);
                    }
                }
            }
        };
        DragDropTouch.prototype._touchmove = function (e) {
            if (this._shouldHandle(e)) {
                // see if target wants to handle move
                var target = this._getTarget(e);
                if (this._dispatchEvent(e, 'mousemove', target)) {
                    this._lastTouch = e;
                    e.preventDefault();
                    return;
                }
                // start dragging
                if (this._dragSource && !this._img) {
                    var delta = this._getDelta(e);
                    if (delta > DragDropTouch._THRESHOLD) {
                        this._dispatchEvent(e, 'dragstart', this._dragSource);
                        this._createImage(e);
                        this._dispatchEvent(e, 'dragenter', target);
                    }
                }
                // continue dragging
                if (this._img) {
                    this._lastTouch = e;
                    e.preventDefault(); // prevent scrolling
                    if (target != this._lastTarget) {
                        this._dispatchEvent(this._lastTouch, 'dragleave', this._lastTarget);
                        this._dispatchEvent(e, 'dragenter', target);
                        this._lastTarget = target;
                    }
                    this._moveImage(e);
                    this._dispatchEvent(e, 'dragover', target);
                }
            }
        };
        DragDropTouch.prototype._touchend = function (e) {
            if (this._shouldHandle(e)) {
                // see if target wants to handle up
                if (this._dispatchEvent(this._lastTouch, 'mouseup', e.target)) {
                    e.preventDefault();
                    return;
                }
                // user clicked the element but didn't drag, so clear the source and simulate a click
                if (!this._img) {
                    this._dragSource = null;
                    this._dispatchEvent(this._lastTouch, 'click', e.target);
                    this._lastClick = Date.now();
                }
                // finish dragging
                this._destroyImage();
                if (this._dragSource) {
                    if (e.type.indexOf('cancel') < 0) {
                        this._dispatchEvent(this._lastTouch, 'drop', this._lastTarget);
                    }
                    this._dispatchEvent(this._lastTouch, 'dragend', this._dragSource);
                    this._reset();
                }
            }
        };
        // ** utilities
        // ignore events that have been handled or that involve more than one touch
        DragDropTouch.prototype._shouldHandle = function (e) {
            return e &&
                !e.defaultPrevented &&
                e.touches && e.touches.length < 2;
        };
        // clear all members
        DragDropTouch.prototype._reset = function () {
            this._destroyImage();
            this._dragSource = null;
            this._lastTouch = null;
            this._lastTarget = null;
            this._ptDown = null;
            this._dataTransfer = new DataTransfer();
        };
        // get point for a touch event
        DragDropTouch.prototype._getPoint = function (e, page) {
            if (e && e.touches) {
                e = e.touches[0];
            }
            return {
                x: page ? e.pageX : e.clientX,
                y: page ? e.pageY : e.clientY
            };
        };
        // get distance between the current touch event and the first one
        DragDropTouch.prototype._getDelta = function (e) {
            var p = this._getPoint(e);
            return Math.abs(p.x - this._ptDown.x) + Math.abs(p.y - this._ptDown.y);
        };
        // get the element at a given touch event
        DragDropTouch.prototype._getTarget = function (e) {
            var pt = this._getPoint(e),
                el = document.elementFromPoint(pt.x, pt.y);
            while (el && getComputedStyle(el).pointerEvents == 'none') {
                el = el.parentElement;
            }
            return el;
        };
        // create drag image from source element
        DragDropTouch.prototype._createImage = function (e) {
            // just in case...
            if (this._img) {
                this._destroyImage();
            }
            // create drag image from custom element or drag source
            var src = this._imgCustom || this._dragSource;
            this._img = src.cloneNode(true);
            this._copyStyle(src, this._img);
            this._img.style.top = this._img.style.left = '-9999px';
            // if creating from drag source, apply offset and opacity
            if (!this._imgCustom) {
                var rc = src.getBoundingClientRect(),
                    pt = this._getPoint(e);
                this._imgOffset = {
                    x: pt.x - rc.left,
                    y: pt.y - rc.top
                };
                this._img.style.opacity = DragDropTouch._OPACITY.toString();
            }
            // add image to document
            this._moveImage(e);
            document.body.appendChild(this._img);
        };
        // dispose of drag image element
        DragDropTouch.prototype._destroyImage = function () {
            if (this._img && this._img.parentElement) {
                this._img.parentElement.removeChild(this._img);
            }
            this._img = null;
            this._imgCustom = null;
        };
        // move the drag image element
        DragDropTouch.prototype._moveImage = function (e) {
            var _this = this;
            if (this._img) {
                requestAnimationFrame(function () {
                    var pt = _this._getPoint(e, true),
                        s = _this._img.style;
                    s.position = 'absolute';
                    s.pointerEvents = 'none';
                    s.zIndex = '999999';
                    s.left = Math.round(pt.x - _this._imgOffset.x) + 'px';
                    s.top = Math.round(pt.y - _this._imgOffset.y) + 'px';
                });
            }
        };
        // copy properties from an object to another
        DragDropTouch.prototype._copyProps = function (dst, src, props) {
            for (var i = 0; i < props.length; i++) {
                var p = props[i];
                dst[p] = src[p];
            }
        };
        DragDropTouch.prototype._copyStyle = function (src, dst) {
            // remove potentially troublesome attributes
            DragDropTouch._rmvAtts.forEach(function (att) {
                dst.removeAttribute(att);
            });
            // copy canvas content
            if (src instanceof HTMLCanvasElement) {
                var cSrc = src,
                    cDst = dst;
                cDst.width = cSrc.width;
                cDst.height = cSrc.height;
                cDst.getContext('2d').drawImage(cSrc, 0, 0);
            }
            // copy style (without transitions)
            var cs = getComputedStyle(src);
            for (var i = 0; i < cs.length; i++) {
                var key = cs[i];
                if (key.indexOf('transition') < 0) {
                    dst.style[key] = cs[key];
                }
            }
            dst.style.pointerEvents = 'none';
            // and repeat for all children

            for (var j = 0; j < src.children.length; j++) {
                this._copyStyle(src.children[i], dst.children[j]);
            }
        };
        DragDropTouch.prototype._dispatchEvent = function (e, type, target) {
            if (e && target) {
                var evt = document.createEvent('Event'),
                    t = e.touches ? e.touches[0] : e;
                evt.initEvent(type, true, true);
                evt.button = 0;
                evt.which = evt.buttons = 1;
                this._copyProps(evt, e, DragDropTouch._kbdProps);
                this._copyProps(evt, t, DragDropTouch._ptProps);
                evt.dataTransfer = this._dataTransfer;
                target.dispatchEvent(evt);
                return evt.defaultPrevented;
            }
            return false;
        };
        // gets an element's closest draggable ancestor
        DragDropTouch.prototype._closestDraggable = function (e) {
            for (; e; e = e.parentElement) {
                if (e.hasAttribute('draggable') && e.draggable) {
                    return e;
                }
            }
            return null;
        };
        return DragDropTouch;
    }());
    /*private*/
    DragDropTouch._instance = new DragDropTouch(); // singleton
    // constants
    DragDropTouch._THRESHOLD = 5; // pixels to move before drag starts
    DragDropTouch._OPACITY = 0.5; // drag image opacity
    DragDropTouch._DBLCLICK = 500; // max ms between clicks in a double click
    DragDropTouch._CTXMENU = 900; // ms to hold before raising 'contextmenu' event
    // copy styles/attributes from drag source to drag image element
    DragDropTouch._rmvAtts = 'id,class,style,draggable'.split(',');
    // synthesize and dispatch an event
    // returns true if the event has been handled (e.preventDefault == true)
    DragDropTouch._kbdProps = 'altKey,ctrlKey,metaKey,shiftKey'.split(',');
    DragDropTouch._ptProps = 'pageX,pageY,clientX,clientY,screenX,screenY'.split(',');
    DragDropTouch_1.DragDropTouch = DragDropTouch;
})(DragDropTouch || (DragDropTouch = {}));