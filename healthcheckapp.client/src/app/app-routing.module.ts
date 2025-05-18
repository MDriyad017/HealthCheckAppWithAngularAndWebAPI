import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { HealthCheckComponent } from './health-check/health-check.component';
import { WorldCitiesComponent } from './world-cities/world-cities.component';
import { WorldCountriesComponent } from './world-countries/world-countries.component';

const routes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'fetch-data', component: FetchDataComponent},
  {path: 'health-check', component: HealthCheckComponent},
  { path: 'world-cities', component: WorldCitiesComponent },
  { path: 'world-countries', component: WorldCountriesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
