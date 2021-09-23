import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgbAccordionConfig } from '@ng-bootstrap/ng-bootstrap';
import { Item } from '../../models/item.model';

@Component({
    selector: 'landing-page-ui',
    templateUrl: './landing-page-ui.component.html',
    styleUrls: ['./landing-page-ui.component.scss']
})
export class LandingPageUIComponent implements OnInit, OnDestroy {
    public focus: boolean;
    public focus1: boolean;
    public focus2: boolean;

    public email: string;
    public contact: string;

    public next = 0;
    public staggeringApproaches = [];

    public firstParts: Item[] = [];
    public secondParts: Item[] = [];
    public thirdParts: Item[] = [];

    constructor(config: NgbAccordionConfig) {
        config.closeOthers = true;
        config.type = 'info';
    }

    myLatlng = new google.maps.LatLng(42.682485651257316, 23.31457610972824);

    mapOptions: google.maps.MapOptions = {
        maxZoom: 17,
        center: this.myLatlng,
        scrollwheel: false
    };

    map: google.maps.Map;
    markers: google.maps.Marker[] = [
        new google.maps.Marker({
            position: new google.maps.LatLng(42.682485651257316, 23.31457610972824),
            label: {
                text: "The Smile Lab",
                color: "#37474F",
                fontSize: "18px",
                fontWeight: "bold"
            },
        })]

    ngOnInit() {
        const navbar = document.getElementsByTagName('nav')[0];
        navbar.classList.add('navbar-transparent');
        const body = document.getElementsByTagName('body')[0];
        body.classList.add('index-page');

        for (let i = 1; i < 4; i++) {
            this.firstParts.push(new Item("service.headline" + i, "service.description" + i, "service" + i + ".jpg"));
            this.secondParts.push(new Item("aboutUs.headline" + i, "aboutUs.description" + i, "aboutUs" + i + ".jpg"));
            this.thirdParts.push(new Item("contacts.headline" + i, "contacts.description" + i, "contacts" + i + ".jpg"));
        }

        this.map = new google.maps.Map(document.getElementById("map"), this.mapOptions);

        var bounds = new google.maps.LatLngBounds();
        this.markers[0].setMap(this.map);
        bounds.extend(this.markers[0].getPosition());

        this.map.fitBounds(bounds);

    }

    ngOnDestroy() {
        const navbar = document.getElementsByTagName('nav')[0];
        navbar.classList.remove('navbar-transparent');
        const body = document.getElementsByTagName('body')[0];
        body.classList.remove('index-page');
    }

    scroll(el: string) {
        const element = document.getElementById(el);
        element.scrollIntoView({ behavior: 'smooth' });
    }

    isInView(el): boolean {
        const rect = el.getBoundingClientRect();
        return (
            rect.top >= 0 &&
            rect.left >= 0 &&
            rect.bottom <= (window.innerHeight || document.documentElement.clientHeight) &&
            rect.right <= (window.innerWidth || document.documentElement.clientWidth)

        );
    }
}

