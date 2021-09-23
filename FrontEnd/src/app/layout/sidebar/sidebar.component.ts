import { Component, OnInit } from '@angular/core';
import { RouteInfo } from '../../data/schema/route-info';

declare const $: any;

export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'dashboard', class: '' },
    { path: '/user-profile', title: 'User Profile',  icon:'person', class: '' },
    { path: '/doctors', title: 'Doctors', icon: 'medication', class: '' },
  //  { path: '/maps', title: 'Maps', icon: 'location_on', class: '' },
    { path: '/patients', title: 'Patients', icon: 'sick', class: '' },
    { path: '/calendar', title: 'Calendar', icon: 'calendar_today', class: '' },
    //{ path: '/typography', title: 'Typography',  icon:'library_books', class: '' },
    //{ path: '/notifications', title: 'Notifications', icon: 'notifications', class: '' }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }

  isMobileMenu() {
      if ($(window).width() > 991) {
          return false;
      }
      return true;
  };
}
