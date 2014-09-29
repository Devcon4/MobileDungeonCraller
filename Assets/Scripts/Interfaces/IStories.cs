using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IStories {

    Information thisStoryC { get; set; }
    List<Information> allStoriesC { get; set; }
    List<GameObject> usableObjectsC { get; set; }
    List<Stats> characterStatsC { get; set; }

}
