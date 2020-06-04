import { Injectable } from '@angular/core';
import { DataService } from '../../../shared/data.service';
import { Bottlecap } from '../../../shared/models';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpaceService {
	bottlecapsChanged = new Subject<Bottlecap[]>();
	bottleCapCollection: Bottlecap[] = [];
	constructor(private dataService: DataService) { }

  //TODO: WHEN A BOTTLECAP IS 'PLACED' ADD IT TO THE SPACE TABLE AND RETRIEVE ALL THE BOTTLECAPS FOR THIS SPACE FROM THAT TABLE
  //TODO: ALSO, FIGURE OUT WHICH PROPERTY IN TABLE CAN BE USED TO ENSURE THE OWNER OF THE BOTTLECAP IS THE ONLY ONE THAT CAN EDIT IT

}
