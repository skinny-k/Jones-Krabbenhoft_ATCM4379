using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyacinth : Plant
{
    public override void Grow()
    {
        switch (_growStage)
        {
            case 0:
                _sprout.SetActive(true);
                break;
            case 1:
                _sprout.SetActive(false);
                _bush.SetActive(true);
                break;
        }

        _growStage++;
    }

    public override void ProgressDay()
    {
        if (_fertilized)
        {
            Grow();
            _fertilized = false;
            _planter.SetFertilizedMaterial(_fertilized);
        }
    }
}
