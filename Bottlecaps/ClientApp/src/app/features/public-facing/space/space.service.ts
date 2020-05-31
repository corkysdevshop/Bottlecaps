import { Injectable } from '@angular/core';
import { DataService } from '../../../shared/data.service';

@Injectable({
  providedIn: 'root'
})
export class SpaceService {

	constructor(private dataService: DataService) { }


}
