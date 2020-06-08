import { Injectable } from '@angular/core';
import { DataService } from '../../../shared/data.service';
import { Bottlecap, Space } from '../../../shared/models';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpaceService {
	spacesChanged = new Subject<Space[]>();
	spaceBottleCapCollection: Space[] = [];
	constructor(private dataService: DataService) {
		this.spacesChanged.subscribe(spaceCaps => {
			this.spaceBottleCapCollection = [];
			this.spaceBottleCapCollection = spaceCaps;
		})
	}

  //TODO: WHEN A BOTTLECAP IS 'PLACED' ADD IT TO THE SPACE TABLE AND RETRIEVE ALL THE BOTTLECAPS FOR THIS SPACE FROM THAT TABLE
  //TODO: ALSO, FIGURE OUT WHICH PROPERTY IN TABLE CAN BE USED TO ENSURE THE OWNER OF THE BOTTLECAP IS THE ONLY ONE THAT CAN EDIT IT
	addBottlecapToSpace(bottlecapId) {
		var space = this.createSpace(bottlecapId);
		this.dataService.placeBottlecapInSpace(space).subscribe(response => {
        console.log("bottlecap added to space: ", response)
		}, err => {
				console.error(err);
		})
	}
	createSpace(bottlecapId) {
		var newSpaceInstance = <Space>{};
		newSpaceInstance.SpaceId = bottlecapId; //TODO: CHANGE THIS TO BOTTLECAPID INSTEAD OF SPACE ID WITH A MIGRATION
        //TODO: ADD REST OF PROPERTIES AS REQUIRED
		newSpaceInstance.SpaceName = "";
		newSpaceInstance.ActiveStatus = "";
		newSpaceInstance.BackgroundImage = "";
		newSpaceInstance.DefaultBottlecapId = "";
		newSpaceInstance.ProfileId = "";

		return newSpaceInstance;
	}
  /**
    * READ
    * */
	getSpaceBottlecaps() {
		this.dataService.getSpaceBottlecaps().subscribe(spaceCaps => {
			console.log("response: ", spaceCaps);
			this.spaceBottleCapCollection = spaceCaps.slice();
      this.spacesChanged.next(this.spaceBottleCapCollection.slice())
		}, err => {
			console.error(err)
		});
	}
}
