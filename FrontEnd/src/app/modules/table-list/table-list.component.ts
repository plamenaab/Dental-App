import { Component, AfterViewInit, ViewChild, ViewEncapsulation } from '@angular/core';
import { UserInfo } from '../../data/schema/user';
import { UserService } from '../../data/service/user.service';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Colum } from '../../data/schema/colum';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { FormType } from '../../shared/enums/form-types.enum';
import { Router } from '@angular/router';

@Component({
    selector: 'app-table-list',
    templateUrl: './table-list.component.html',
    styleUrls: ['./table-list.component.scss']
})
export class TableListComponent implements AfterViewInit {
    displayColumns: Colum[] = [new Colum("ID"), new Colum("Name"), new Colum("Country"), new Colum("City"), new Colum("Cost"), new Colum("Date")];

    data: UserInfo[] = [];
    dataSource: MatTableDataSource<UserInfo>;

    @ViewChild(MatPaginator) paginator: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    filterGroup = new FormGroup({
        country: new FormControl('', [Validators.required]),
        city: new FormControl('', [Validators.required]),
        startDate: new FormControl('', [Validators.required]),
        endDate: new FormControl('', [Validators.required]),
        filter: new FormControl()
    });

    countries: string[] = [];
    cities: string[] = []
    date = new Date(2021, 10, 5);

    formTypes = FormType;

    constructor(private userService: UserService, private router: Router) {
        this.userService.getUsers().subscribe((data: UserInfo[]) => {
            this.data = data;
            this.dataSource = new MatTableDataSource(data);
            this.countries = data.map(x => x.country);
            this.cities = data.map(x => x.city);
        });
    }

    ngAfterViewInit() {
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;

        this.filterGroup.get("filter").valueChanges.subscribe(filterValue => {
            this.dataSource.filter = filterValue.trim().toLowerCase();

            if (this.dataSource.paginator) {
                this.dataSource.paginator.firstPage();
            }
        });
    }

    filterData() {
        var filteredData = this.data.filter(x =>
            (this.filterGroup.get("country").value as string[]).indexOf(x.country) !== -1 &&
            x.city == this.filterGroup.get("city").value &&
            new Date(x.date) >= this.filterGroup.get("startDate").value &&
            new Date(x.date) <= this.filterGroup.get("endDate").value)

        this.dataSource = new MatTableDataSource(filteredData);

        if (this.dataSource.paginator) {
            this.dataSource.paginator.firstPage();
        }
    }

    navigateDoctor() {
        this.router.navigate(["/doctor-info"]);
    }

    navigateDoctor2() {
        this.router.navigate(["/doctor-info2"]);

    }
    navigateDoctor3() {
        this.router.navigate(["/doctor-info3"]);

    }
    navigateDoctor4() {
        this.router.navigate(["/doctor-info4"]);

    }
    navigateDoctor5() {
        this.router.navigate(["/doctor-info5"]);

    }
    //navigateDoctor6() {
    //    this.router.navigate(["/doctor-info6"]);

    //}
    //navigateDoctor7() {
    //    this.router.navigate(["/doctor-info7"]);

    //}
}
