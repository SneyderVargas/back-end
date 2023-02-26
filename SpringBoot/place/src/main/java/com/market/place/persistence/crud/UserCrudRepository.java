package com.market.place.persistence.crud;

import com.market.place.persistence.entity.UserEntity;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface UserCrudRepository extends CrudRepository<UserEntity, Integer> {
}
