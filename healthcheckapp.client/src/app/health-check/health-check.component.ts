import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-health-check',
  templateUrl: './health-check.component.html',
  styleUrl: './health-check.component.css'
})
export class HealthCheckComponent implements OnInit {
  public result?: Result;
  constructor(private http: HttpClient) {}
  ngOnInit() {
    this.http.get<Result>(environment.baseUrl + 'api/health').subscribe(res => {
      this.result = res;
    }, err => console.error(err));
  }
}

interface Result {
  checks: Check[];
  totalStatus: string;
  totalResponseTime: number;
}

interface Check {
  name: String;
  responseTime: number;
  status: string;
  description: string;
}
