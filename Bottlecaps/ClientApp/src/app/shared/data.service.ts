import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tag, Bottlecap, Profile, Link, Space } from './models';

@Injectable({
  providedIn: 'root'
})
export class DataService {
	public tags: Tag[];
	constructor(private http: HttpClient,
		@Inject('BASE_URL') private baseUrl: string
	) { }
  /**
    * CREATE (POST)
    */
    //TODO: PASS PROFILE ID FROM LOGGED IN USER
	addBottlecap(bottlecap: Bottlecap) {
		return this.http.post<Bottlecap>(this.baseUrl + 'api/Bottlecaps', bottlecap);
	}
	placeBottlecapInSpace(space: Space) {
		console.log("space", space);
		return this.http.post<Bottlecap>(this.baseUrl + 'api/Spaces', space);
	}
  /**
    * READ (GET)
    */
    //TODO: POPULATE HOME PAGE WITH SPACE TAGS
	getSpaceTags(spaceId) {
		this.http.get<Tag[]>(this.baseUrl + 'api/Tags').subscribe(result => {
			console.log('success: ', result); // TODO: FIX THIS ENDPOINT TO TAKE A PARAMETER FOR THE SPACE
			//this.tags =result;
		}, error => console.error("error", error));
	}

	getProfile(ProfileId: number) {
		return this.http.get<Profile>(this.baseUrl + 'api/Profiles/' + ProfileId);
	}

	getMyCollection(ProfileId: number) {
		return this.http.get<Bottlecap[]>(this.baseUrl + 'api/Bottlecaps/mybottlecaps/'+ ProfileId);
	}

	getBottlecapTags(BottlecapId: number) {
		return this.http.get <Tag[]>(this.baseUrl + 'api/Tags/' + BottlecapId);
	}

	getBottlecapLinks(BottlecapId: number) {
		return this.http.get<Link[]>(this.baseUrl + 'api/Links/' + BottlecapId);
	}

	getSpaceBottlecaps(spaces) {
		return this.http.get<Bottlecap[]>(this.baseUrl + 'api/Spaces',spaces);
	}
  /**
    * UPDATE (PUT)
    */
    //TODO: IMPLEMENT
    //TODO: CHANGE THIS TO A PUT
	updatePosition(space: Space) {
		console.log('space.SpaceId', space.SpaceId);
        //TODO: FIGURE OUT IF I HAVE TO SEND ID IN URL
		return this.http.put<Space>(this.baseUrl + 'api/Bottlecaps/' + space.SpaceId, space);
	}
  /**
    * DELETE (DELETE)
    */
	deleteBottlecap(Bottlecap: Bottlecap) {
		return this.http.delete<Bottlecap>(this.baseUrl + 'api/Bottlecaps/' + Bottlecap.bottlecapId);
	}
}

