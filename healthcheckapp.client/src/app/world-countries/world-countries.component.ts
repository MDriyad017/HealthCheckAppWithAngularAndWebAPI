import { Component, OnInit, ViewChild, viewChild } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http'
import { environment } from '../../environments/environment';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

import { Country } from './country'

@Component({
  selector: 'app-world-countries',
  templateUrl: './world-countries.component.html',
  styleUrl: './world-countries.component.css'
})
export class WorldCountriesComponent {
  public displayedColumns: string[] = ['id', 'name', 'iso2', 'iso3'];
  public countries!: MatTableDataSource<Country>;

  defaultPageIndex: number = 0;
  defaultPageSize: number = 10;
  defaultFilterColumn: string = "name";
  filterQuery?: string;

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.loadData();
  }

  loadData(query?: string) {
    var pageEvent = new PageEvent();
    pageEvent.pageIndex = this.defaultPageIndex;
    pageEvent.pageSize = this.defaultPageSize;
    this.filterQuery = query;
    this.getData(pageEvent);
  }

  getData(event: PageEvent) {
    var url = environment.baseUrl + 'api/Countries';
    var params = new HttpParams()
      .set("pageIndex", event.pageIndex.toString())
      .set("pageSize", event.pageSize.toString())

    if (this.filterQuery) {
      params = params
        .set("filterColumn", this.defaultFilterColumn)
        .set("filterQuery", this.filterQuery)
    }

    this.http.get<any>(url, { params })
      .subscribe({
        next: (res) => {
          this.paginator.length = res.totalCount;
          this.paginator.pageIndex = res.pageIndex;
          this.paginator.pageSize = res.pageSize;
          this.countries = new MatTableDataSource<Country>(res.data);
        },
        error: (err) => console.log(err)
      });

  }

}
