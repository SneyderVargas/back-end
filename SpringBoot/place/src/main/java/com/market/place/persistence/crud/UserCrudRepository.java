package com.market.place.persistence.crud;

import com.market.place.persistence.entity.UserEntity;
import org.springframework.data.repository.CrudRepository;

import java.util.List;
import java.util.Optional;

public interface UserCrudRepository extends CrudRepository<UserEntity, Long> {
    Optional<List<UserEntity>> findByActive(int active);
}
